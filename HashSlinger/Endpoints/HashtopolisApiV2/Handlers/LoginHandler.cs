namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.Handlers;

using Api.Handlers.Commands;
using Api.Handlers.Queries;
using DTO;
using Mapster;
using MediatR;
using Models;
using Models.Enums;
using Serilog;

/// <summary>Handles Hashtopolis login requests.</summary>
// ReSharper disable once UnusedMember.Global
public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly IMediator _mediator;

    /// <summary>Initializes a new instance of the <see cref="LoginHandler" /> class.</summary>
    /// <param name="mediator">The mediator.</param>
    public LoginHandler(IMediator mediator) => _mediator = mediator;


    /// <inheritdoc />
    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        Agent? agent = await _mediator.Send(new GetAgentByTokenQuery(request.Token), cancellationToken)
            .ConfigureAwait(false);

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

        await _mediator.Send(new UpdateAgentCommand(agent), cancellationToken).ConfigureAwait(true);
        return request.Adapt<LoginResponse>() with
        {
            Response = HashtopolisConstants.SuccessResponse,
            Timeout = HashSlingerConfiguration.AgentTimeout
        };
    }
}
