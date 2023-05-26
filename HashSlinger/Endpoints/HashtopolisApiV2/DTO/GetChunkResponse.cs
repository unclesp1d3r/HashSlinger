﻿namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;

public record GetChunkResponse(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("response")]
    string Response,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("chunkId")]
    int? ChunkId,
    [property: JsonPropertyName("skip")] int? Skip,
    [property: JsonPropertyName("length")] int? Length
) : IHashtopolisMessage;