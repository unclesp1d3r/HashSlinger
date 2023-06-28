namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.Handlers;

using Api.Handlers.Commands;
using Api.Handlers.Queries;
using DTO;
using Mapster;
using MediatR;
using Serilog;
using Shared.Models;
using Shared.Models.Enums;

/// <summary>
/// Handles the Hashtopolis API v2 GetHashlist endpoint.
/// </summary>
public class GetHashlistHandler : IRequestHandler<GetHashlistRequest, GetHashlistResponse>
{
    private readonly IMediator _mediator;

    /// <summary>Initializes a new instance of the <see cref="GetHashlistHandler" /> class.</summary>
    /// <param name="mediator">The mediator.</param>
    public GetHashlistHandler(IMediator mediator) => _mediator = mediator;

    /// <inheritdoc />
    public async Task<GetHashlistResponse> Handle(GetHashlistRequest request, CancellationToken cancellationToken)
    {
        // Verify Agent
        Agent? agent = await _mediator.Send(new GetAgentByTokenQuery(request.Token), cancellationToken)
            .ConfigureAwait(false);

        if (agent is null)
        {
            Log.Error("Agent not found");
            return request.Adapt<GetHashlistResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Agent not found."
            };
        }

        // Update Agent LastSeen
        await _mediator.Send(new TouchAgentCommand(request.Token, AgentActions.GetHashlist), cancellationToken)
            .ConfigureAwait(false);


        Hashlist? hashlist = await _mediator.Send(new GetHashlistByIdQuery(request.HashlistId), cancellationToken)
            .ConfigureAwait(true);


        if (hashlist is null)
            return request.Adapt<GetHashlistResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Hashlist not found."
            };

        // Verify Agent has access to Hashlist
        if (agent.AccessGroups.All(x => x.Id != hashlist.AccessGroupId) || hashlist.IsSecret != agent.IsTrusted)
            return request.Adapt<GetHashlistResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Agent does not have access to this hashlist."
            };

        // Return Hashlist Url.
        // We should expand this beyond static files into meta hashlists that are generated on the fly.
        return request.Adapt<GetHashlistResponse>() with
        {
            Response = HashtopolisConstants.SuccessResponse,
            Url = $"{HashtopolisConstants.HashlistDownloadUrl}/{hashlist.Id}?token={request.Token}"
        };
    }
}
