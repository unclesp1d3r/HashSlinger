namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using HashSlinger.Api.Data;

/// <summary>
///     This is used by the client to check if there is an update available for the client script. Type specifies
///     the type of the client.
/// </summary>
public record CheckClientVersionRequest(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("version")]
    string Version,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("token")] string Token
) : IHashtopolisRequest
{
    /// <inheritdoc />
    public Task<IHashtopolisMessage> ProcessRequestAsync(HashSlingerContext db)
    {
        throw new NotImplementedException();
    }
}
