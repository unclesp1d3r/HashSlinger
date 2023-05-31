namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using HashSlinger.Api.Data;

/// <summary>Sent by the client to login and get the timeout setting.</summary>
public record LoginRequest(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("clientSignature")]
    string ClientSignature,
    [property: JsonPropertyName("token")] string Token
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
