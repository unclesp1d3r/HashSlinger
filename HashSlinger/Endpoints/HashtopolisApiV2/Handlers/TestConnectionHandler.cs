namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.Handlers;

using DTO;
using Mapster;
using MediatR;
using Serilog;

/// <summary>Handles the Hashtopolis testConnection call.</summary>

// ReSharper disable once UnusedMember.Global
// ReSharper disable once UnusedType.Global
public class TestConnectionHandler : IRequestHandler<TestConnectionRequest, TestConnectionResponse>
{
    /// <summary>Handles a request</summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    public Task<TestConnectionResponse> Handle(TestConnectionRequest request, CancellationToken cancellationToken)
    {
        Log.Debug("TestConnectionRequest received");
        return Task.FromResult(request.Adapt<TestConnectionResponse>() with
        {
            Response = HashtopolisConstants.SuccessResponse
        });
    }
}
