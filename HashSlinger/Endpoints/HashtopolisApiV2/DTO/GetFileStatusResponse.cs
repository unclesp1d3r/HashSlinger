namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;

/// <inheritdoc />
public record GetFileStatusResponse(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("response")]
    string Response,
    [property: JsonPropertyName("filenames")]
    IReadOnlyList<string> FileNames,
    [property: JsonPropertyName("message")]
    string? Message = null
);
