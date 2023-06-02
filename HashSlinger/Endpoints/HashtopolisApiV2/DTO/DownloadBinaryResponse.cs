namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;

/// <inheritdoc />
public record DownloadBinaryResponse(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("response")]
    string Response,
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("executable")]
    string? Executable,
    [property: JsonPropertyName("keyspaceCommand")]
    string? KeyspaceCommand,
    [property: JsonPropertyName("skipCommand")]
    string? SkipCommand,
    [property: JsonPropertyName("limitCommand")]
    string? LimitCommand,
    [property: JsonPropertyName("message")]
    string? Message = null
) : IHashtopolisMessage;
