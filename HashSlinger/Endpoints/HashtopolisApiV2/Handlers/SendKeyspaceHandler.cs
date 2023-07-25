namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.Handlers;

using Api.Handlers.Commands;
using Api.Handlers.Queries;
using DTO;
using Mapster;
using MediatR;
using Shared.Models;
using Shared.Models.Enums;

/// <summary>
/// Handles the Hashtopolis API v2 SendKeyspace endpoint.
/// </summary>
public class SendKeyspaceHandler : IRequestHandler<SendKeyspaceRequest, SendKeyspaceResponse>
{
    private readonly IMediator _mediator;

    /// <summary>Initializes a new instance of the <see cref="SendKeyspaceHandler" /> class.</summary>
    /// <param name="mediator">The mediator.</param>
    public SendKeyspaceHandler(IMediator mediator) => _mediator = mediator;

    /// <inheritdoc />
    public async Task<SendKeyspaceResponse> Handle(SendKeyspaceRequest request, CancellationToken cancellationToken)
    {
        var validAgent = await _mediator.Send(new ValidateAgentTokenQuery(request.Token), cancellationToken)
                                 .ConfigureAwait(true);
        if (!validAgent)
            return request.Adapt<SendKeyspaceResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Invalid token"
            };

        await _mediator.Send(new TouchAgentCommand(request.Token, AgentActions.SendKeyspace), cancellationToken)
                .ConfigureAwait(false);


        Task? task = await _mediator.Send(new GetTaskByIdQuery(request.Token, request.TaskId), cancellationToken)
                             .ConfigureAwait(true);

        if (task is null)
            return request.Adapt<SendKeyspaceResponse>() with { Response = "error", Message = "Task not found" };

        task.Keyspace = request.Keyspace;
        await _mediator.Send(new UpdateTaskCommand(task), cancellationToken).ConfigureAwait(true);
        return request.Adapt<SendKeyspaceResponse>() with
        {
            Response = HashtopolisConstants.SuccessResponse,
            Keyspace = HashtopolisConstants.OkResponse
        };
    }
}
