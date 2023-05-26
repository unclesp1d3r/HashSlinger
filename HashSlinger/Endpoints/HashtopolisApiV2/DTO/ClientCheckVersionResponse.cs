namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;

/// <summary>The server response to the clientCheckVersion action.</summary>
public record ClientCheckVersionResponse(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("response")]
    string Response,
    [property: JsonPropertyName("version")]
    string Version,
    [property: JsonPropertyName("url")] string? Url
) : IHashtopolisMessage;
