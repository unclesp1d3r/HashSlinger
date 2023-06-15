// ReSharper disable UnusedMember.Global

namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.Handlers;

using DTO;
using Mapster;
using MediatR;
using Serilog;

/// <summary>Handles the Hashtopolis testConnection call.</summary>
public class TestConnectionHandler : IRequestHandler<TestConnectionRequest, TestConnectionResponse>
{
    /// <inheritdoc />
    public async Task<TestConnectionResponse> Handle(
        TestConnectionRequest request,
        CancellationToken cancellationToken
    )
    {
        Log.Debug("TestConnectionRequest received");
        return request.Adapt<TestConnectionResponse>() with
        {
            Response = HashtopolisConstants.SuccessResponse
        };
    }
}
