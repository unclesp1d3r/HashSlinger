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


        // Find an existing chunk to assign
        Log.Information("Checking for available chunks for task {task} and agent {agent}", task.Id, agent.Id);
        Chunk? chunk = await _mediator.Send(new GetAvailableChunkQuery(task.Id, agent.Id), cancellationToken)
                                      .ConfigureAwait(false);
        if (chunk is not null)
        {
            // Assign Chunk to Agent
            Log.Information("Assigning chunk {chunk} to agent {agent}", chunk.Id, agent.Id);
            chunk.Agent = agent;
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


        return request.Adapt<GetChunkResponse>() with
        {
            Response = HashtopolisConstants.ErrorResponse,
            Message = "Ran of of implementation time."
        };
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
