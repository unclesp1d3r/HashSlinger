namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using DAL;

/// <summary>The client requests the current task it should work on</summary>
public record GetChunkRequest(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("token")] string Token,
    [property: JsonPropertyName("taskId")] int? TaskId
) : IHashtopolisRequest
{
    /// <inheritdoc />
    public IHashtopolisMessage ProcessRequest()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<IHashtopolisMessage> ProcessRequestAsync(IHashSlingerRepository repository)
    {
        throw new NotImplementedException();
    }
}
