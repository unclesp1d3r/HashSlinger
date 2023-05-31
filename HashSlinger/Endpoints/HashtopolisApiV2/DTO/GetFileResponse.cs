namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;

/// <inheritdoc />
public record GetFileResponse(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("response")]
    string Response,
    [property: JsonPropertyName("extension")]
    string Extension,
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("filesize")]
    int? FileSize
) : IHashtopolisMessage;
