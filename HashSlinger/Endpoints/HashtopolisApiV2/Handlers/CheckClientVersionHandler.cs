// ReSharper disable UnusedMember.Global

namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.Handlers;

using DAL;
using DTO;
using Mapster;
using MediatR;
using Models;
using Models.Enums;
using Serilog;

/// <summary>Handles the Hashtopolis check client version call.</summary>
public class
    CheckClientVersionHandler : IRequestHandler<CheckClientVersionRequest, CheckClientVersionResponse>
{
    private readonly Repository _repository;

    /// <summary>Initializes a new instance of the <see cref="CheckClientVersionHandler" /> class.</summary>
    /// <param name="repository"></param>
    public CheckClientVersionHandler(Repository repository) => _repository = repository;

    /// <inheritdoc />
    public async Task<CheckClientVersionResponse> Handle(
        CheckClientVersionRequest request,
        CancellationToken cancellationToken
    )
    {
        Log.Debug("Processing request {request}", this);
        Agent? agent = await _repository.GetAgentByTokenAsync(request.Token).ConfigureAwait(false);
        if (agent == null)
        {
            Log.Information("Agent not found");
            return request.Adapt<CheckClientVersionResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Agent not found."
            };
        }

        agent.LastAction = AgentActions.CheckClientVersion;
        agent.LastSeenTime = DateTime.UtcNow;

        int result = await _repository.UpdateAgentAsync(agent).ConfigureAwait(true);
        if (result != 1) Log.Error("Failed to update agent");

        AgentBinary? clientBinary = await _repository.GetAgentBinaryAsync(request.Type, request.Version)
            .ConfigureAwait(false);

        if (clientBinary == null)
        {
            Log.Information("No client binary found for type {type}", request.Type);
            return request.Adapt<CheckClientVersionResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = $"No client binary found for type {request.Type}"
            };
        }

        if (clientBinary.Version != request.Version)
        {
            Log.Information("Client update available: {version} -> {newVersion}",
                request.Version,
                clientBinary.Version);
            return request.Adapt<CheckClientVersionResponse>() with
            {
                Response = HashtopolisConstants.SuccessResponse,
                Version = HashtopolisConstants.ClientVersionCheckUpdateAvailable,
                Url = clientBinary.DownloadUrl
            };
        }

        Log.Information("Client is up to date");
        return request.Adapt<CheckClientVersionResponse>() with
        {
            Response = HashtopolisConstants.SuccessResponse,
            Version = HashtopolisConstants.ClientVersionCheckCurrent
        };
    }
}
