namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.Handlers;

using Api.Handlers.Commands;
using Api.Handlers.Queries;
using DTO;
using Mapster;
using MediatR;
using Serilog;
using Shared.Models;
using Shared.Models.Enums;

/// <summary>Handles the Hashtopolis API v2 GetTask endpoint.</summary>
public class GetTaskHandler : IRequestHandler<GetTaskRequest, GetTaskResponse>
{
    private readonly IMediator _mediator;

    /// <summary>Initializes a new instance of the <see cref="GetTaskHandler" /> class.</summary>
    /// <param name="mediator">The mediator.</param>
    public GetTaskHandler(IMediator mediator) => _mediator = mediator;

    /// <inheritdoc />
    public async Task<GetTaskResponse> Handle(GetTaskRequest request, CancellationToken cancellationToken)
    {
        // Verify Agent
        Agent? agent = await _mediator.Send(new GetAgentByTokenQuery(request.Token), cancellationToken)
            .ConfigureAwait(false);

        if (agent is null)
        {
            Log.Error("Agent not found");
            return request.Adapt<GetTaskResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Agent not found."
            };
        }

        // Update Agent LastSeen
        await _mediator.Send(new TouchAgentCommand(request.Token, AgentActions.GetTask), cancellationToken)
            .ConfigureAwait(false);


        // Check for HealthChecks
        var healthChecks = await _mediator.Send(new GetPendingHealthCheckForAgentQuery(agent.Id), cancellationToken)
            .ConfigureAwait(true);

        if (healthChecks)
        {
            Log.Information("HealthChecks found for Agent {AgentId}", agent.Id);
            return request.Adapt<GetTaskResponse>() with
            {
                Response = HashtopolisConstants.SuccessResponse,
                Message = "HealthChecks found for Agent.",
                TaskId = -1
            };
        }

        // Verify Agent is Active
        if (!agent.IsActive)
        {
            Log.Error("Agent is disabled");
            return request.Adapt<GetTaskResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Agent is disabled."
            };
        }

        // Check for Assigned Task
        Task? nextTask = await _mediator.Send(new GetNextTaskForAgentQuery(request.Token), cancellationToken)
            .ConfigureAwait(true);

        if (nextTask is not null)
            return request.Adapt<GetTaskResponse>() with
            {
                Response = HashtopolisConstants.SuccessResponse,
                TaskId = nextTask.Id,
                HashlistId = nextTask.TaskWrapper.HashlistId,
                Bench = HashSlingerConfiguration.BenchmarkTime,
                StatusTimer = HashSlingerConfiguration.StatusTimer,
                BenchType = nextTask.UseNewBenchmark ? "speed" : "run",
                CrackerId = nextTask.CrackerBinary?.Id,
                HashlistAlias = HashSlingerConfiguration.HashlistAlias,
                Files = nextTask.Files.Select(f => f.FileName).ToList(),
                Keyspace = nextTask.Keyspace,
                UsePreprocessor = nextTask.UsePreprocessor,
                PreprocessorId = nextTask.Preprocessor?.Id,
                PreprocessorCommand = nextTask.PreprocessorCommand,
                EnforcePipe = nextTask.EnforcePipe,
                UseBrain = HashSlingerConfiguration.HashcatBrainEnable,
                BrainHost = HashSlingerConfiguration.HashcatBrainHost,
                BrainPort = HashSlingerConfiguration.HashcatBrainPort,
                BrainPassword = HashSlingerConfiguration.HashcatBrainPass,
                BrainFeatures = 3 // I'm pretty sure I'm going to remove brain support.
            };

        return request.Adapt<GetTaskResponse>() with
        {
            Response = HashtopolisConstants.SuccessResponse,
            Message = HashtopolisConstants.NoTaskAvailableMessage,
            TaskId = null
        };
    }
}
