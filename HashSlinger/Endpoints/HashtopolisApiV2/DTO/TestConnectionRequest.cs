namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using DAL;
using Serilog;

/// <inheritdoc />
public record TestConnectionRequest
    ([property: JsonPropertyName("action")] string Action) : IHashtopolisRequest
{
    /// <inheritdoc />
    public Task<IHashtopolisMessage> ProcessRequestAsync(Repository repository)
    {
        Log.Debug("TestConnectionRequest received");
        return Task.FromResult<IHashtopolisMessage>(new TestConnectionResponse("testConnection",
            HashtopolisConstants.SuccessResponse,
            null));
    }
}
