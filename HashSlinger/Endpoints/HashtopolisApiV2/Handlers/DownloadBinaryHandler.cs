namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.Handlers;

using Api.Handlers.Queries;
using DTO;
using Mapster;
using MediatR;
using Models;

/// <summary>Handles the Hashtopolis API v2 downloadBinary endpoint.</summary>
// ReSharper disable once UnusedMember.Global
public class DownloadBinaryHandler : IRequestHandler<DownloadBinaryRequest, DownloadBinaryResponse>
{
    private readonly IMediator _mediator;

    /// <summary>Initializes a new instance of the <see cref="DownloadBinaryHandler" /> class.</summary>
    /// <param name="mediator">The mediator.</param>
    public DownloadBinaryHandler(IMediator mediator) => _mediator = mediator;

    /// <inheritdoc />
    public async Task<DownloadBinaryResponse> Handle(
        DownloadBinaryRequest request,
        CancellationToken cancellationToken
    )
    {
        Agent? agent = await _mediator
            .Send(new GetAgentByTokenQuery { Token = request.Token }, cancellationToken)
            .ConfigureAwait(false);
        if (agent == null)
            return request.Adapt<DownloadBinaryResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Invalid token"
            };

        // This is the best I can come up with, given how weird the Hashtopolis API is.
        switch (request.Type)
        {
            case "7zr":
                DownloadableBinary? sevenZipBinary = await _mediator
                    .Send(new GetBinaryByNameQuery("7zr"), cancellationToken)
                    .ConfigureAwait(true);
                if (sevenZipBinary == null)
                    return request.Adapt<DownloadBinaryResponse>() with
                    {
                        Response = HashtopolisConstants.ErrorResponse,
                        Message = "7zr binary not found"
                    };
                return request.Adapt<DownloadBinaryResponse>() with
                {
                    Response = HashtopolisConstants.SuccessResponse,
                    Url = sevenZipBinary.DownloadUrl
                };
            case "preprocessor":
                return request.Adapt<DownloadBinaryResponse>() with
                {
                    Response = HashtopolisConstants.SuccessResponse,
                    Message = $"Requested binary type: {request.Type}"
                };
            case "cracker":
                return request.Adapt<DownloadBinaryResponse>() with
                {
                    Response = HashtopolisConstants.SuccessResponse,
                    Message = $"Requested binary type: {request.Type}"
                };
            default:
                return request.Adapt<DownloadBinaryResponse>() with
                {
                    Response = HashtopolisConstants.ErrorResponse,
                    Message = $"Unknown binary type: {request.Type}"
                };
        }
    }
}
