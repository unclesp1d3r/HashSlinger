namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.Handlers;

using System.Globalization;
using DTO;
using HashSlinger.Api.Handlers.Commands;
using HashSlinger.Api.Handlers.Queries;
using Mapster;
using MediatR;
using Serilog;
using Shared.Models;
using Shared.Models.Enums;

/// <summary>
/// Handles a request to send a benchmark result.
/// </summary>
// ReSharper disable once UnusedMember.Global
public class SendBenchmarkHandler : IRequestHandler<SendBenchmarkRequest, SendBenchmarkResponse>
{
    private readonly IMediator _mediator;

    /// <summary>Initializes a new instance of the <see cref="SendBenchmarkHandler" /> class.</summary>
    /// <param name="mediator">The mediator.</param>
    public SendBenchmarkHandler(IMediator mediator) => _mediator = mediator;


    /// <inheritdoc />
    public async Task<SendBenchmarkResponse> Handle(SendBenchmarkRequest request, CancellationToken cancellationToken)
    {
        // There has to be a benchmark result or the request is invalid
        if (string.IsNullOrWhiteSpace(request.Result))
            return request.Adapt<SendBenchmarkResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Benchmark is invalid."
            };

        // Verify Agent
        Log.Information("Verifying agent with token: {request}", request.Token);
        Agent? agent = await _mediator.Send(new GetAgentByTokenQuery(request.Token), cancellationToken)
                                      .ConfigureAwait(false);

        if (agent is null)
            return request.Adapt<SendBenchmarkResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Agent not found."
            };

        if (!agent.IsActive)
            return request.Adapt<SendBenchmarkResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Agent is not active."
            };

        // Update Agent LastSeen
        await _mediator.Send(new TouchAgentCommand(request.Token, AgentActions.SendBenchmark), cancellationToken)
                       .ConfigureAwait(false);

        // Get Task
        Log.Information("Getting task for agent: {agent}", agent.Id);
        Task? task = await _mediator.Send(new GetTaskByIdQuery(request.Token, request.TaskId), cancellationToken)
                                    .ConfigureAwait(false);
        if (task is null)
            return request.Adapt<SendBenchmarkResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Task not found."
            };


        // Check if task is assigned to agent
        Log.Information("Checking if task {task} is assigned to agent: {agent}", task.Id, agent.Id);
        Assignment? assignment = task.Assignments.SingleOrDefault(a => a.AgentId == agent.Id);
        if (assignment is null)
            return request.Adapt<SendBenchmarkResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Task not assigned to agent."
            };

        var benchmark = request.Result!;
        if (string.IsNullOrEmpty(benchmark))
            return request.Adapt<SendBenchmarkResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Benchmark is invalid."
            };

        // Check if task is using the speed benchmark, otherwise it uses the runtime benchmark
        if (task.UseNewBenchmark)
        {
            if (!request.Result.Contains(':'))
                return request.Adapt<SendBenchmarkResponse>() with
                {
                    Response = HashtopolisConstants.ErrorResponse,
                    Message = "Benchmark is invalid."
                };

            var benchmarkStrings = request.Result.Split(':');
            if (HandlerUtilities.IsInvalidSpeedBenchmarkValue(benchmarkStrings))
                return request.Adapt<SendBenchmarkResponse>() with
                {
                    Response = HashtopolisConstants.ErrorResponse,
                    Message = "Benchmark is invalid."
                };

            //TODO: Do rule splitting logic.
        }
        else
        {
            if (!double.TryParse(request.Result, out var benchmarkSeconds))
                return request.Adapt<SendBenchmarkResponse>() with
                {
                    Response = HashtopolisConstants.ErrorResponse,
                    Message = "Benchmark is invalid."
                };
            if (benchmarkSeconds < 0)
                return request.Adapt<SendBenchmarkResponse>() with
                {
                    Response = HashtopolisConstants.ErrorResponse,
                    Message = "Benchmark is invalid."
                };

            benchmark
                = (benchmarkSeconds / HashSlingerConfiguration.BenchmarkTime * 100).ToString(CultureInfo.InvariantCulture);
        }

        // Update Benchmark
        Log.Information("Updating benchmark for task: {task}", task.Id);
        await _mediator.Send(new UpdateBenchmarkCommand(task.Id, request.Token, benchmark), cancellationToken)
                       .ConfigureAwait(false);

        return request.Adapt<SendBenchmarkResponse>() with
        {
            Response = HashtopolisConstants.SuccessResponse,
            Message = "Benchmark updated."
        };
    }
}
