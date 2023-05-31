namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using Data;

/// <summary>When the client executed a health check it should send back the results.</summary>
public record SendHealthCheckRequest(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("token")] string Token,
    [property: JsonPropertyName("numCracked")]
    int? NumCracked,
    [property: JsonPropertyName("start")] int? Start,
    [property: JsonPropertyName("end")] int? End,
    [property: JsonPropertyName("numGpus")]
    int? NumGpus,
    [property: JsonPropertyName("errors")] IReadOnlyList<string> Errors,
    [property: JsonPropertyName("checkId")]
    int? CheckId
) : IHashtopolisRequest
{
    /// <inheritdoc />
    public Task<IHashtopolisMessage> ProcessRequestAsync(HashSlingerContext db, ILogger logger)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public IHashtopolisMessage ProcessRequest()
    {
        throw new NotImplementedException();
    }
}
