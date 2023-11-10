namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.Handlers;

using Api.Handlers.Commands;
using Api.Handlers.Queries;
using DTO;
using Mapster;
using MediatR;
using Serilog;
using Shared.Models;
using Shared.Models.Enums;

/// <summary>
/// Handles the Hashtopolis API v2 GetChunk endpoint.
/// </summary>
public class GetChunkHandler : IRequestHandler<GetChunkRequest, GetChunkResponse>
{
    private readonly IMediator _mediator;

    /// <summary>Initializes a new instance of the <see cref="GetChunkHandler" /> class.</summary>
    /// <param name="mediator">The mediator.</param>
    public GetChunkHandler(IMediator mediator) => _mediator = mediator;

    /// <inheritdoc />
    public async Task<GetChunkResponse> Handle(GetChunkRequest request, CancellationToken cancellationToken)
    {
        // Verify Agent
        Log.Information("Verifying agent with token: {request}", request.Token);
        Agent? agent = await _mediator.Send(new GetAgentByTokenQuery(request.Token), cancellationToken)
                                      .ConfigureAwait(false);

        if (agent is null)
            return request.Adapt<GetChunkResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Agent not found."
            };

        if (!agent.IsActive)
            return request.Adapt<GetChunkResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Agent is not active."
            };

        // Update Agent LastSeen
        await _mediator.Send(new TouchAgentCommand(request.Token, AgentActions.GetChunk), cancellationToken)
                       .ConfigureAwait(false);

        // Check for HealthChecks
        Log.Information("Checking for pending health checks for agent: {agent}", agent.Id);
        var healthChecksPending = await _mediator.Send(new GetPendingHealthCheckForAgentQuery(agent.Id), cancellationToken)
                                                 .ConfigureAwait(true);
        if (healthChecksPending)
            return request.Adapt<GetChunkResponse>() with
            {
                Response = HashtopolisConstants.SuccessResponse,
                Status = GetChuckResponseStatusConstants.HealthCheck
            };

        // Get Task
        Log.Information("Getting task for agent: {agent}", agent.Id);
        Task? task = await _mediator.Send(new GetTaskByIdQuery(request.Token, request.TaskId), cancellationToken)
                                    .ConfigureAwait(false);
        if (task is null)
            return request.Adapt<GetChunkResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Task not found."
            };

        // Check if task is assigned to agent
        Log.Information("Checking if task {task} is assigned to agent: {agent}", task.Id, agent.Id);
        Assignment? assignment = task.Assignments.SingleOrDefault(a => a.AgentId == agent.Id);
        if (assignment is null)
            return request.Adapt<GetChunkResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Task not assigned to agent."
            };

        // Check if task is saturated
        Log.Information("Checking if task {task} is saturated for agent: {agent}", task.Id, agent.Id);
        var otherAssignmentCount = task.Assignments.Count(a => a.AgentId != agent.Id);
        if ((task.IsSmall && otherAssignmentCount >= 1) || (task.MaxAgents != 0 && otherAssignmentCount >= task.MaxAgents))
            return request.Adapt<GetChunkResponse>() with
            {
                Response = HashtopolisConstants.SuccessResponse,
                Status = GetChuckResponseStatusConstants.FullyDispatched
            };


        // Check for keyspace
        Log.Information("Checking if task {task} has a keyspace.", task.Id);
        if (task.Keyspace == 0)
            return request.Adapt<GetChunkResponse>() with
            {
                Response = HashtopolisConstants.SuccessResponse,
                Status = GetChuckResponseStatusConstants.KeyspaceRequired
            };

        // Check for benchmark
        Log.Information("Checking if task {task} has a benchmark.", task.Id);
        if (string.IsNullOrWhiteSpace(assignment.Benchmark)
            && task is { IsSmall: false, StaticChunks: TaskStaticChunking.Normal })
            return request.Adapt<GetChunkResponse>() with
            {
                Response = HashtopolisConstants.SuccessResponse,
                Status = GetChuckResponseStatusConstants.Benchmark
            };

        // Check for fully dispatched
        //TODO: Check if task is fully dispatched

        // Find an existing chunk to assign
        Log.Information("Checking for available chunks for task {task} and agent {agent}", task.Id, agent.Id);
        Chunk? chunk = await _mediator.Send(new GetAvailableChunkQuery(task.Id, agent.Id), cancellationToken)
                                      .ConfigureAwait(false);
        if (chunk is not null)
        {
            // Assign Chunk to Agent
            Log.Information("Assigning chunk {chunk} to agent {agent}", chunk.Id, agent.Id);
            chunk.Agent = agent;
            chunk.DispatchTime = DateTime.UtcNow;
            await _mediator.Send(new UpdateTaskCommand(task), cancellationToken).ConfigureAwait(true);
            return request.Adapt<GetChunkResponse>() with
            {
                Response = HashtopolisConstants.SuccessResponse,
                Status = GetChuckResponseStatusConstants.Ok,
                ChunkId = chunk.Id,
                Length = chunk.Length,
                Skip = chunk.Skip
            };
        }


        // Create a new chunk to assign
        var remainingTolerance = HashSlingerConfiguration.ChunkTolerance / 100 + 1;
        if (task.SkipKeyspace > task.KeyspaceProgress)
        {
            task.KeyspaceProgress = task.SkipKeyspace;
            await _mediator.Send(new UpdateTaskCommand(task), cancellationToken).ConfigureAwait(true);
        }

        // Check if there is enough keyspace remaining to create a new chunk
        var remainingKeyspace = task.Keyspace - task.KeyspaceProgress;
        if (remainingKeyspace == 0 && !task.UsePreprocessor)
        {
            task.TaskWrapper.IsCompleted = true;
            await _mediator.Send(new UpdateTaskCommand(task), cancellationToken).ConfigureAwait(true);
        }


        if (task.ChunkTime <= 0)
        {
            task.ChunkTime = HashSlingerConfiguration.ChunkDuration;
            await _mediator.Send(new UpdateTaskCommand(task), cancellationToken).ConfigureAwait(true);
        }

        // Let's figure out what size the new chunk should be.
        ulong chunkSize = 0;
        switch (task.StaticChunks)
        {
            case TaskStaticChunking.ChunkSize:
                if (task.ChunkSize == 0)
                    return request.Adapt<GetChunkResponse>() with
                    {
                        Response = HashtopolisConstants.ErrorResponse,
                        Message = "Chunk size cannot be 0."
                    };

                chunkSize = (ulong)task.ChunkSize;
                break;
            case TaskStaticChunking.NumberOfChunks:
                if (task.ChunkSize == 0 || task.ChunkSize > 10000)
                    return request.Adapt<GetChunkResponse>() with
                    {
                        Response = HashtopolisConstants.ErrorResponse,
                        Message = "Chunk size is not valid."
                    };

                chunkSize = (ulong)Math.Ceiling(task.Keyspace / (double)task.ChunkSize);

                break;
            case TaskStaticChunking.Normal:
                if (string.IsNullOrWhiteSpace(assignment.Benchmark))
                    return request.Adapt<GetChunkResponse>() with
                    {
                        Response = HashtopolisConstants.ErrorResponse,
                        Message = "No benchmark provided."
                    };


                if (assignment.Benchmark.Contains(':'))
                {
                    var benchmarkStrings = assignment.Benchmark.Split(':');
                    if (HandlerUtilities.IsInvalidSpeedBenchmarkValue(benchmarkStrings))
                        return request.Adapt<GetChunkResponse>() with
                        {
                            Response = HashtopolisConstants.ErrorResponse,
                            Message = "Invalid benchmark."
                        };

                    chunkSize = GetChunkSizeFromSpeedBenchmark(benchmarkStrings, task);
                }
                else if (!int.TryParse(assignment.Benchmark, out var benchmarkSeconds))
                {
                    return request.Adapt<GetChunkResponse>() with
                    {
                        Response = HashtopolisConstants.ErrorResponse,
                        Message = "Invalid benchmark."
                    };
                }
                else
                {
                    chunkSize = GetChunkSizeForRuntimeBenchmark(benchmarkSeconds, task);
                }

                break;
            default:
                return request.Adapt<GetChunkResponse>() with
                {
                    Response = HashtopolisConstants.ErrorResponse,
                    Message = "Unknown chunking method."
                };
                break;
        }

        // Create the chunk
        Log.Information("Creating chunk for task {task} and agent {agent}, of size {size}", task.Id, agent.Id, chunkSize);
        var chunkStart = task.KeyspaceProgress;
        var chunkLength = chunkSize;
        if (remainingKeyspace / chunkLength <= (ulong)remainingTolerance && !task.UsePreprocessor)
            chunkLength = remainingKeyspace;
        chunk = new Chunk()
        {
            Agent = agent,
            Task = task,
            Length = chunkLength,
            Skip = chunkStart,
            DispatchTime = DateTime.UtcNow
        };
        await _mediator.Send(new UpdateChunkCommand(chunk), cancellationToken).ConfigureAwait(true);
        return request.Adapt<GetChunkResponse>() with
        {
            Response = HashtopolisConstants.SuccessResponse,
            Status = GetChuckResponseStatusConstants.Ok,
            ChunkId = chunk.Id,
            Length = chunk.Length,
            Skip = chunk.Skip
        };
    }


    private static ulong GetChunkSizeForRuntimeBenchmark(int benchmarkSeconds, Task task)
    {
        ulong chunkSize;
        if (benchmarkSeconds <= 0) chunkSize = task.Keyspace;
        else
            chunkSize = (ulong)Math.Floor(
                // ReSharper disable once PossibleLossOfFraction
                (double)(task.Keyspace * (ulong)benchmarkSeconds * (ulong)task.ChunkTime / 100));

        return chunkSize;
    }

    private static ulong GetChunkSizeFromSpeedBenchmark(IReadOnlyList<string> benchmarkStrings, Task task)
    {
        var value1 = double.Parse(benchmarkStrings[0]);
        var value2 = double.Parse(benchmarkStrings[1]);
        var factor = task.ChunkTime / value2 * 1000;
        var chunkSize = (ulong)Math.Floor(factor * value1);
        return chunkSize;
    }
}

internal static class GetChuckResponseStatusConstants
{
    internal const string Ok = "OK";
    internal const string KeyspaceRequired = "keyspace_required";
    internal const string FullyDispatched = "fully_dispatched";
    internal const string HealthCheck = "health_check";
    internal const string Benchmark = "benchmark";
}
