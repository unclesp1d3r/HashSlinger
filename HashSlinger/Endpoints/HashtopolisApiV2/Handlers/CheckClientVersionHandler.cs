// ReSharper disable UnusedMember.Global

namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.Handlers;

using Api.Handlers.Commands;
using Api.Handlers.Queries;
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
    private readonly IMediator _mediator;

    /// <summary>Initializes a new instance of the <see cref="CheckClientVersionHandler" /> class.</summary>
    /// <param name="mediator">The mediator.</param>
    public CheckClientVersionHandler(IMediator mediator) => _mediator = mediator;

    /// <inheritdoc />
    public async Task<CheckClientVersionResponse> Handle(
        CheckClientVersionRequest request,
        CancellationToken cancellationToken
    )
    {
        Log.Debug("Processing request {request}", this);
        Agent? agent = await _mediator
            .Send(new GetAgentByTokenQuery { Token = request.Token }, cancellationToken)
            .ConfigureAwait(false);
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

        await _mediator.Send(new UpdateAgentCommand(agent), cancellationToken).ConfigureAwait(true);
        AgentBinary? clientBinary = await _mediator
            .Send(new GetAgentBinaryQuery { Type = request.Type, CurrentVersion = request.Version },
                cancellationToken)
            .ConfigureAwait(false);


        if (clientBinary is null)
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
