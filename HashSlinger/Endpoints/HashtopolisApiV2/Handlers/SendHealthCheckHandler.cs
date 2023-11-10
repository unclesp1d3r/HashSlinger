namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.Handlers;

using Api.Handlers.Commands;
using Api.Handlers.Queries;
using DTO;
using Mapster;
using MediatR;
using Shared.Models.Enums;

/// <summary>Handles the Hashtopolis API v2 SendHealthCheck endpoint.</summary>
public class SendHealthCheckHandler : IRequestHandler<SendHealthCheckRequest, SendHealthCheckResponse>
{
    private readonly IMediator _mediator;

    /// <summary>Initializes a new instance of the <see cref="SendHealthCheckHandler" /> class.</summary>
    /// <param name="mediator">The mediator.</param>
    public SendHealthCheckHandler(IMediator mediator) => _mediator = mediator;

    /// <inheritdoc />
    public async Task<SendHealthCheckResponse> Handle(SendHealthCheckRequest request, CancellationToken cancellationToken)
    {
        var validAgent = await _mediator.Send(new ValidateAgentTokenQuery(request.Token), cancellationToken)
                                        .ConfigureAwait(true);
        if (!validAgent)
            return request.Adapt<SendHealthCheckResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Invalid token"
            };

        await _mediator.Send(new TouchAgentCommand(request.Token, AgentActions.GetFileStatus), cancellationToken)
                       .ConfigureAwait(false);

        await _mediator.Send(new UpdateHealthCheckWithResultCommand(request.Token,
                               request.NumCracked,
                               request.Start,
                               request.End,
                               request.NumGpus,
                               request.Errors,
                               request.CheckId),
                           cancellationToken)
                       .ConfigureAwait(false);
        return request.Adapt<SendHealthCheckResponse>() with
        {
            Response = HashtopolisConstants.OkResponse
        };
    }
}
