namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.Handlers;

using Api.Handlers.Commands;
using Api.Handlers.Queries;
using DTO;
using Mapster;
using MediatR;
using Models;
using Models.Enums;
using Serilog;

/// <summary>Handles the Hashtopolis API request to update the client information.</summary>

// ReSharper disable once UnusedMember.Global
// ReSharper disable once UnusedType.Global
public class UpdateInformationHandler : IRequestHandler<UpdateInformationRequest, UpdateInformationResponse>
{
    private readonly IMediator _mediator;

    /// <summary>Initializes a new instance of the <see cref="UpdateInformationHandler" /> class.</summary>
    /// <param name="mediator">The mediator.</param>
    public UpdateInformationHandler(IMediator mediator) => _mediator = mediator;

    /// <inheritdoc />
    public async Task<UpdateInformationResponse> Handle(
        UpdateInformationRequest request,
        CancellationToken cancellationToken
    )
    {
        Agent? agent = await _mediator.Send(new GetAgentByTokenQuery(request.Token), cancellationToken)
                                      .ConfigureAwait(false);
        if (agent == null)
        {
            Log.Information("Agent not found");
            return request.Adapt<UpdateInformationResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Agent not found."
            };
        }

        if (request.OperatingSystem != null)
            agent.OperatingSystem = request.OperatingSystem.Adapt<AgentOperatingSystems>();
        agent.LastAction = AgentActions.UpdateClientInformation;
        agent.LastSeenTime = DateTime.UtcNow;
        agent.Devices = request.Devices.Adapt<List<string>>();
        agent.LastIp = request.IpAddress;
        if (string.IsNullOrWhiteSpace(agent.Uid)) agent.CpuOnly = !agent.CheckForGpuDevices();
        agent.Uid = request.Uid;

        await _mediator.Send(new UpdateAgentCommand(agent), cancellationToken).ConfigureAwait(true);
        return request.Adapt<UpdateInformationResponse>() with
        {
            Response = HashtopolisConstants.SuccessResponse
        };
    }
}
