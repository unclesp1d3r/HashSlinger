namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.Handlers;

using Api.Handlers.Commands;
using Api.Handlers.Queries;
using DTO;
using Mapster;
using MediatR;
using Serilog;
using Shared.Models;
using Shared.Models.Enums;

/// <summary>Handles the Hashtopolis API v2 GetHealthCheck endpoint.</summary>
public class GetHealthCheckHandler : IRequestHandler<GetHealthCheckRequest, GetHealthCheckResponse>
{
    private readonly IMediator _mediator;

    /// <summary>Initializes a new instance of the <see cref="GetHealthCheckHandler" /> class.</summary>
    /// <param name="mediator">The mediator.</param>
    public GetHealthCheckHandler(IMediator mediator) => _mediator = mediator;

    /// <inheritdoc />
    public async Task<GetHealthCheckResponse> Handle(GetHealthCheckRequest request, CancellationToken cancellationToken)
    {
        // Verify Agent
        Agent? agent = await _mediator.Send(new GetAgentByTokenQuery(request.Token), cancellationToken)
            .ConfigureAwait(false);

        if (agent is null)
        {
            Log.Error("Agent not found");
            return request.Adapt<GetHealthCheckResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Agent not found."
            };
        }

        // Update Agent LastSeen
        await _mediator.Send(new TouchAgentCommand(request.Token, AgentActions.GetHealthCheck), cancellationToken)
            .ConfigureAwait(false);

        HealthCheck? healthCheck = await _mediator.Send(new GetHealthChecksForAgentQuery(agent.Id), cancellationToken)
            .ConfigureAwait(true);

        if (healthCheck is null)
            return request.Adapt<GetHealthCheckResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "No HealthChecks found for Agent."
            };

        Log.Information("HealthChecks found for Agent {AgentId}", agent.Id);
        return request.Adapt<GetHealthCheckResponse>() with
        {
            Response = HashtopolisConstants.SuccessResponse,
            Attack = healthCheck.AttackCmd,
            CrackerBinaryId = healthCheck.CrackerBinary?.Id,
            Hashes = healthCheck.TestHashes,
            CheckId = healthCheck.Id,
            HashlistAlias = healthCheck.HashListAlias
        };
    }
}
