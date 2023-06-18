namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;

/// <inheritdoc />
public record DownloadBinaryResponse(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("response"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string Response,
    [property: JsonPropertyName("url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string Url,
    [property: JsonPropertyName("name"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string Name,
    [property: JsonPropertyName("executable"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? Executable,
    [property: JsonPropertyName("keyspaceCommand"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? KeyspaceCommand = null,
    [property: JsonPropertyName("skipCommand"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? SkipCommand = null,
    [property: JsonPropertyName("limitCommand"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? LimitCommand = null,
    [property: JsonPropertyName("message"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? Message = null
) : IHashtopolisMessage;
