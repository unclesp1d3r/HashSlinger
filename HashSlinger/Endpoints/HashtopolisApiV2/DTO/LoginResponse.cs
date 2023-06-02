namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;

/// <inheritdoc />
public record LoginResponse(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("response")]
    string Response,
    [property: JsonPropertyName("timeout")]
    int? Timeout,
    [property: JsonPropertyName("message")]
    string? Message = null
) : IHashtopolisMessage;
