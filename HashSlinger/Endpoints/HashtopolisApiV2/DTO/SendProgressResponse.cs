namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;

/// <inheritdoc />
public record SendProgressResponse(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("response")]
    string Response,
    [property: JsonPropertyName("cracked")]
    int? Cracked,
    [property: JsonPropertyName("skipped")]
    int? Skipped,
    [property: JsonPropertyName("zap")] IReadOnlyList<string>? Zap
) : IHashtopolisMessage;
