namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;

/// <inheritdoc />
public record GetChunkResponse(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("response")]
    string Response,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("chunkId")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    int? ChunkId,
    [property: JsonPropertyName("skip")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    ulong? Skip,
    [property: JsonPropertyName("length")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    ulong? Length,
    [property: JsonPropertyName("message")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? Message = null
) : IHashtopolisMessage;
