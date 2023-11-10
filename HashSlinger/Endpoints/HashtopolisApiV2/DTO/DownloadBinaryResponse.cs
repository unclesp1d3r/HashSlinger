namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;

/// <inheritdoc />
public record DownloadBinaryResponse(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("response")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string Response,
    [property: JsonPropertyName("url")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string Url,
    [property: JsonPropertyName("name")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string Name,
    [property: JsonPropertyName("executable")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? Executable,
    [property: JsonPropertyName("keyspaceCommand")]
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? KeyspaceCommand = null,
    [property: JsonPropertyName("skipCommand")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? SkipCommand = null,
    [property: JsonPropertyName("limitCommand")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? LimitCommand = null,
    [property: JsonPropertyName("message")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? Message = null
) : IHashtopolisMessage;
