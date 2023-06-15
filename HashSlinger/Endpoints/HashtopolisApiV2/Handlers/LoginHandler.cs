// ReSharper disable UnusedMember.Global

namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.Handlers;

using DAL;
using DTO;
using Mapster;
using MediatR;
using Models;
using Models.Enums;
using Serilog;

/// <summary>Handles Hashtopolis login requests.</summary>
public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly Repository _repository;

    /// <summary>Initializes a new instance of the <see cref="LoginHandler" /> class.</summary>
    /// <param name="repository">The repository.</param>
    public LoginHandler(Repository repository) => _repository = repository;


    /// <inheritdoc />
    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        Agent? agent = await _repository.GetAgentByTokenAsync(request.Token).ConfigureAwait(true);

        if (agent is null)
        {
            Log.Error("Agent not found");
            return request.Adapt<LoginResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Agent not found."
            };
        }

        agent.ClientSignature = request.ClientSignature;
        agent.LastSeenTime = DateTime.UtcNow;
        agent.LastAction = AgentActions.Login;

        await _repository.UpdateAgentAsync(agent).ConfigureAwait(true);
        return request.Adapt<LoginResponse>() with
        {
            Response = HashtopolisConstants.SuccessResponse,
            Timeout = HashSlingerConfiguration.AgentTimeout
        };
    }
}
