namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using Data;

/// <summary>Reports the progress of the current chunk, in the given reporting interval.</summary>
public record SendProgressRequest(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("token")] string Token,
    [property: JsonPropertyName("chunkId")]
    int? ChunkId,
    [property: JsonPropertyName("keyspaceProgress")]
    int? KeyspaceProgress,
    [property: JsonPropertyName("relativeProgress")]
    string RelativeProgress,
    [property: JsonPropertyName("speed")] int? Speed,
    [property: JsonPropertyName("state")] int? State,
    [property: JsonPropertyName("cracks")] IReadOnlyList<List<string>> Cracks,
    [property: JsonPropertyName("gpuTemp")]
    IReadOnlyList<int>? GpuTemp,
    [property: JsonPropertyName("gpuUtil")]
    IReadOnlyList<int>? GpuUtil
) : IHashtopolisRequest
{
    /// <inheritdoc />
    public Task<IHashtopolisMessage> ProcessRequestAsync(HashSlingerContext db)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public IHashtopolisMessage ProcessRequest()
    {
        throw new NotImplementedException();
    }
}
