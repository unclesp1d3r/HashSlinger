// ReSharper disable StringLiteralTypo

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
    long? FileSize,
    [property: JsonPropertyName("message")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? Message = null
) : IHashtopolisMessage;
