namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;

/// <inheritdoc />
public record GetChunkResponse(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("response")]
    string Response,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("chunkId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    int? ChunkId,
    [property: JsonPropertyName("skip"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    ulong? Skip,
    [property: JsonPropertyName("length"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    ulong? Length,
    [property: JsonPropertyName("message"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? Message = null
) : IHashtopolisMessage;
