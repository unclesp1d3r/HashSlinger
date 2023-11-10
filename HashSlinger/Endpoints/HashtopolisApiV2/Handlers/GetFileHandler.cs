namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.Handlers;

using Api.Handlers.Commands;
using Api.Handlers.Queries;
using ClientApiV1;
using DTO;
using Mapster;
using MediatR;
using Serilog;
using Shared.Models;
using Shared.Models.Enums;

/// <summary>
/// Handles the Hashtopolis API v2 GetFile endpoint.
/// </summary>
public class GetFileHandler : IRequestHandler<GetFileRequest, GetFileResponse>
{
    private readonly IMediator _mediator;

    /// <summary>Initializes a new instance of the <see cref="GetFileHandler" /> class.</summary>
    /// <param name="mediator">The mediator.</param>
    public GetFileHandler(IMediator mediator) => _mediator = mediator;

    /// <inheritdoc />
    public async Task<GetFileResponse> Handle(GetFileRequest request, CancellationToken cancellationToken)
    {
        var validAgent = await _mediator.Send(new ValidateAgentTokenQuery(request.Token), cancellationToken)
                                        .ConfigureAwait(true);
        if (!validAgent)
            return request.Adapt<GetFileResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Invalid token"
            };

        await _mediator.Send(new TouchAgentCommand(request.Token, AgentActions.GetFile), cancellationToken)
                       .ConfigureAwait(false);

        File? theFile = await _mediator.Send(new GetFileQuery(request.TaskId, request.FileName), cancellationToken)
                                       .ConfigureAwait(true);

        Log.Information("Found file {FileName} from task {TaskId}; {theFile}", request.FileName, request.TaskId, theFile);
        if (theFile is null)
            return request.Adapt<GetFileResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "File not found"
            };

        return request.Adapt<GetFileResponse>() with
        {
            Response = HashtopolisConstants.SuccessResponse,
            Extension = ".txt",
            FileSize = theFile.Size,
            Url = GetDownloadUrl(theFile)
        };
    }

    private static string GetDownloadUrl(File theFile)
    {
        return theFile.FileType switch
        {
            FileType.WordList => $"/getFile/{theFile.Id}",
            FileType.Rule => $"{FileEndpoints.ApiPrefix}/rule/{theFile.FileName}",
            FileType.Mask => $"{FileEndpoints.ApiPrefix}/mask/{theFile.FileName}",
            FileType.HashList => $"{FileEndpoints.ApiPrefix}/hashlist/{theFile.FileName}",
            _ => throw new ArgumentOutOfRangeException(nameof(theFile))
        };
    }
}
