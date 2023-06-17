namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;

/// <inheritdoc />
public record ClientErrorResponse(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("response")]
    string Response,
    [property: JsonPropertyName("message"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? Message = null
) : IHashtopolisMessage;
