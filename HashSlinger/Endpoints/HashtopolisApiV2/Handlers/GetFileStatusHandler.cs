namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.Handlers;

using Api.Handlers.Commands;
using Api.Handlers.Queries;
using DTO;
using Mapster;
using MediatR;
using Shared.Models.Enums;

/// <summary>Handles the Hashtopolis API v2 GetFileStatus endpoint.</summary>
// ReSharper disable once UnusedMember.Global
public class GetFileStatusHandler : IRequestHandler<GetFileStatusRequest, GetFileStatusResponse>
{
    private readonly IMediator _mediator;

    /// <summary>Initializes a new instance of the <see cref="GetFileStatusHandler" /> class.</summary>
    /// <param name="mediator">The mediator.</param>
    public GetFileStatusHandler(IMediator mediator) => _mediator = mediator;

    /// <inheritdoc />
    public async Task<GetFileStatusResponse> Handle(GetFileStatusRequest request, CancellationToken cancellationToken)
    {
        var validAgent = await _mediator.Send(new ValidateAgentTokenQuery(request.Token), cancellationToken)
                                        .ConfigureAwait(true);
        if (!validAgent)
            return request.Adapt<GetFileStatusResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Invalid token"
            };

        await _mediator.Send(new TouchAgentCommand(request.Token, AgentActions.GetFileStatus), cancellationToken)
                       .ConfigureAwait(false);

        var deletedFiles = await _mediator.Send(new GetDeletedFileNamesQuery(), cancellationToken).ConfigureAwait(true);

        return request.Adapt<GetFileStatusResponse>() with
        {
            Response = HashtopolisConstants.SuccessResponse,
            Message = "Success",
            FileNames = deletedFiles
        };
    }
}
