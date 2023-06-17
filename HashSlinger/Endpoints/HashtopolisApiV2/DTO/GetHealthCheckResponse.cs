namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;

/// <inheritdoc />
public record GetHealthCheckResponse(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("response")]
    string Response,
    [property: JsonPropertyName("attack")] string Attack,
    [property: JsonPropertyName("crackerBinaryId")]
    int? CrackerBinaryId,
    [property: JsonPropertyName("hashes")] IReadOnlyList<string> Hashes,
    [property: JsonPropertyName("checkId")]
    int? CheckId,
    [property: JsonPropertyName("hashlistAlias")]
    string? HashlistAlias,
    [property: JsonPropertyName("message"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? Message = null
) : IHashtopolisMessage;
