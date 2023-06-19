// ReSharper disable StringLiteralTypo

namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;

/// <inheritdoc />
public record GetTaskResponse(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("response")]
    string Response,
    [property: JsonPropertyName("taskId")]
    int? TaskId,
    [property: JsonPropertyName("attackcmd"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? AttackCommand,
    [property: JsonPropertyName("hashlistId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    int? HashlistId,
    [property: JsonPropertyName("bench"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    int? Bench,
    [property: JsonPropertyName("statustimer"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    int? StatusTimer,
    [property: JsonPropertyName("benchType"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? BenchType,
    [property: JsonPropertyName("crackerId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    int? CrackerId,
    [property: JsonPropertyName("hashlistAlias"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? HashlistAlias,
    [property: JsonPropertyName("files"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    IReadOnlyList<string>? Files,
    [property: JsonPropertyName("keyspace"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    ulong? Keyspace,
    [property: JsonPropertyName("usePreprocessor"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    bool? UsePreprocessor,
    [property: JsonPropertyName("preprocessor"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    int? PreprocessorId,
    [property: JsonPropertyName("preprocessorCommand"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? PreprocessorCommand,
    [property: JsonPropertyName("enforcePipe"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    bool? EnforcePipe,
    [property: JsonPropertyName("slowHash"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    bool? SlowHash,
    [property: JsonPropertyName("useBrain"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    bool? UseBrain,
    [property: JsonPropertyName("brainHost"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? BrainHost,
    [property: JsonPropertyName("brainPort"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    int? BrainPort,
    [property: JsonPropertyName("brainPass"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? BrainPassword,
    [property: JsonPropertyName("brainFeatures"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    int? BrainFeatures,
    [property: JsonPropertyName("reason"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? Reason,
    [property: JsonPropertyName("message"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? Message = null
) : IHashtopolisMessage;
