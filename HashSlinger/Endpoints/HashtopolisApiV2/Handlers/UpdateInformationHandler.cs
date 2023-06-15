// ReSharper disable UnusedMember.Global

namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.Handlers;

using DAL;
using DTO;
using Mapster;
using MediatR;
using Models;
using Models.Enums;
using Serilog;

/// <summary>Handles the Hashtopolis API request to update the client information.</summary>
/// <seealso
///     cref="MediatR.IRequestHandler&lt;HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO.UpdateInformationRequest, HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO.UpdateInformationResponse&gt;" />
public class UpdateInformationHandler : IRequestHandler<UpdateInformationRequest, UpdateInformationResponse>
{
    private readonly Repository _repository;

    /// <summary>Initializes a new instance of the <see cref="UpdateInformationHandler" /> class.</summary>
    /// <param name="repository">The repository.</param>
    public UpdateInformationHandler(Repository repository) => _repository = repository;

    /// <inheritdoc />
    public async Task<UpdateInformationResponse> Handle(
        UpdateInformationRequest request,
        CancellationToken cancellationToken
    )
    {
        Agent? agent = await _repository.GetAgentByTokenAsync(request.Token).ConfigureAwait(false);
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

        int result = await _repository.UpdateAgentAsync(agent).ConfigureAwait(true);
        if (result != 1) Log.Error("Failed to update agent");

        return request.Adapt<UpdateInformationResponse>() with
        {
            Response = HashtopolisConstants.SuccessResponse
        };
    }
}
