﻿namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.Handlers;

using Api.Handlers.Commands;
using Api.Handlers.Queries;
using DTO;
using Mapster;
using MediatR;
using Shared.Models;
using Shared.Models.Enums;
using Utilities;

/// <summary>Handles the Hashtopolis API v2 downloadBinary endpoint.</summary>

// ReSharper disable once UnusedMember.Global
// ReSharper disable once UnusedType.Global
public class DownloadBinaryHandler : IRequestHandler<DownloadBinaryRequest, DownloadBinaryResponse>
{
    private readonly IMediator _mediator;

    /// <summary>Initializes a new instance of the <see cref="DownloadBinaryHandler" /> class.</summary>
    /// <param name="mediator">The mediator.</param>
    public DownloadBinaryHandler(IMediator mediator) => _mediator = mediator;

    /// <inheritdoc />
    public async Task<DownloadBinaryResponse> Handle(DownloadBinaryRequest request, CancellationToken cancellationToken)
    {
        Agent? agent = await _mediator.Send(new GetAgentByTokenQuery(request.Token), cancellationToken).ConfigureAwait(true);
        if (agent is null)
            return request.Adapt<DownloadBinaryResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Invalid token"
            };
        var extension = Utilities.GetFileExtension(agent.OperatingSystem);
        await _mediator.Send(new TouchAgentCommand(request.Token, AgentActions.DownloadBinary), cancellationToken)
                       .ConfigureAwait(false);

        // This is the best I can come up with, given how weird the Hashtopolis API is.
        return request.Type switch
        {
            "7zr" => await GetExtractorResponseAsync(request, extension).ConfigureAwait(true),
            "uftpd" => request.Adapt<DownloadBinaryResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Multicast is not currently supported."
            },
            "preprocessor" => request.Adapt<DownloadBinaryResponse>() with
            {
                // Still need to implement this.
                Response = HashtopolisConstants.SuccessResponse,
                Message = $"Requested binary type: {request.Type}"
            },
            "cracker" => await GetCrackerResponseAsync(request, extension).ConfigureAwait(true),
            var _ => request.Adapt<DownloadBinaryResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = $"Unknown binary type: {request.Type}"
            }
        };
    }

    private async Task<DownloadBinaryResponse> GetCrackerResponseAsync(DownloadBinaryRequest request, string extension)
    {
        DownloadableBinary? crackerBinary = await _mediator
                                                  .Send(new GetCrackerBinaryQuery(request.BinaryVersionId))
                                                  .ConfigureAwait(true);
        if (crackerBinary == null)
            return request.Adapt<DownloadBinaryResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Cracker binary not found"
            };
        return request.Adapt<DownloadBinaryResponse>() with
        {
            Response = HashtopolisConstants.SuccessResponse,
            Url = crackerBinary.DownloadUrl,
            Executable = $"{crackerBinary.Executable}{extension}",
            Name = crackerBinary.Name
        };
    }

    private async Task<DownloadBinaryResponse> GetExtractorResponseAsync(DownloadBinaryRequest request, string extension)
    {
        // The hashtopolis python agent doesn't actually follow the documented APIs.
        // The documentation says that the 7zr binary is downloaded from the URL value in the
        // response, but the python agent actually downloads the binary from the Executable value.

        DownloadableBinary? sevenZipBinary = await _mediator.Send(new GetBinaryByNameQuery("7zr")).ConfigureAwait(true);
        if (sevenZipBinary == null)
            return request.Adapt<DownloadBinaryResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "7zr binary not found"
            };
        return request.Adapt<DownloadBinaryResponse>() with
        {
            Response = HashtopolisConstants.SuccessResponse,
            Executable = $"{sevenZipBinary.DownloadUrl}{extension}"
        };
    }
}
