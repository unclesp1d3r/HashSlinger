namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using DAL;

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
    [property: JsonPropertyName("cracks")] ICollection<ICollection<string>> Cracks,
    [property: JsonPropertyName("gpuTemp")]
    ICollection<int>? GpuTemp,
    [property: JsonPropertyName("gpuUtil")]
    ICollection<int>? GpuUtil
) : IHashtopolisRequest
{
    /// <inheritdoc />
    public Task<IHashtopolisMessage> ProcessRequestAsync(Repository repository)
    {
        throw new NotImplementedException();
    }
}
