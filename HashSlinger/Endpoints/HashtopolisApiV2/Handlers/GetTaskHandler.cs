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
        // We need to expand this to support different types of priorities (prioritize by project, hashtype, etc)
        GetNextTaskForAgentProjectionResponse? nextTask = await _mediator
            .Send(new GetNextTaskForAgentProjectionQuery(agent.Id), cancellationToken)
            .ConfigureAwait(true);
        Log.Information("Next Task for Agent {AgentId} is {@TaskId}", agent.Id, nextTask);
        if (nextTask is not null)
            return nextTask.Adapt<GetTaskResponse>() with
            {
                Response = HashtopolisConstants.SuccessResponse,
                Bench = HashSlingerConfiguration.BenchmarkTime,
                StatusTimer = HashSlingerConfiguration.StatusTimer,
                HashlistAlias = HashSlingerConfiguration.HashlistAlias,
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
