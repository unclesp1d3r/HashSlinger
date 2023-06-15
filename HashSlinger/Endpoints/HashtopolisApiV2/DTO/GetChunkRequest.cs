namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;

/// <summary>The client requests the current task it should work on</summary>
public record GetChunkRequest(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("token")] string Token,
    [property: JsonPropertyName("taskId")] int? TaskId
) : IHashtopolisRequest;
