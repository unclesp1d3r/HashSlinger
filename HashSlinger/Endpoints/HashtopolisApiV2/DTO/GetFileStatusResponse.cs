namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;

/// <summary>Send a response to a request for a file status.</summary>
/// <param name="Action"></param>
/// <param name="Response"></param>
/// <param name="FileNames"></param>
/// <param name="Message"></param>
public record GetFileStatusResponse(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("response")]
    string Response,
    [property: JsonPropertyName("filenames")]
    IReadOnlyList<string> FileNames,
    [property: JsonPropertyName("message")]
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? Message = null
);
