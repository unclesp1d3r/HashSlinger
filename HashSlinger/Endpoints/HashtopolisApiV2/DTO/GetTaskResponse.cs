namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;

/// <inheritdoc />
public record GetTaskResponse(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("response")]
    string Response,
    [property: JsonPropertyName("taskId")] int? TaskId,
    [property: JsonPropertyName("attackcmd")]
    string? Attackcmd,
    [property: JsonPropertyName("hashlistId")]
    int? HashlistId,
    [property: JsonPropertyName("bench")] int? Bench,
    [property: JsonPropertyName("statustimer")]
    int? Statustimer,
    [property: JsonPropertyName("benchType")]
    string? BenchType,
    [property: JsonPropertyName("crackerId")]
    int? CrackerId,
    [property: JsonPropertyName("hashlistAlias")]
    string? HashlistAlias,
    [property: JsonPropertyName("files")] IReadOnlyList<string>? Files,
    [property: JsonPropertyName("keyspace")]
    int? Keyspace,
    [property: JsonPropertyName("usePrince")]
    bool? UsePrince,
    [property: JsonPropertyName("enforcePipe")]
    bool? EnforcePipe,
    [property: JsonPropertyName("slowHash")]
    bool? SlowHash,
    [property: JsonPropertyName("useBrain")]
    bool? UseBrain,
    [property: JsonPropertyName("brainHost")]
    string? BrainHost,
    [property: JsonPropertyName("brainPort")]
    int? BrainPort,
    [property: JsonPropertyName("brainPass")]
    string? BrainPass,
    [property: JsonPropertyName("brainFeatures")]
    int? BrainFeatures,
    [property: JsonPropertyName("reason")] string? Reason,
    [property: JsonPropertyName("message")]
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? Message = null
) : IHashtopolisMessage;
