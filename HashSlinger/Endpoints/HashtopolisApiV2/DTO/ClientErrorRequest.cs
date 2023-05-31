namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using HashSlinger.Api.Data;

/// <summary>
///     In case there happens an error with Hashcat/Cracker on the client, it can submit the error message to the
///     server where it will be assigned to the agent and shown on the page. The chunk ID is optional and can be
///     null if not available.
/// </summary>
public record ClientErrorRequest(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("taskId")] int? TaskId,
    [property: JsonPropertyName("token")] string Token,
    [property: JsonPropertyName("chunkId")]
    int? ChunkId,
    [property: JsonPropertyName("message")]
    string Message
) : IHashtopolisRequest
{
    /// <inheritdoc />
    public IHashtopolisMessage ProcessRequest()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<IHashtopolisMessage> ProcessRequestAsync(HashSlingerContext db)
    {
        throw new NotImplementedException();
    }
}
