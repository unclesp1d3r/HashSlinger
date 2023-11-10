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
    [property: JsonPropertyName("attackcmd")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? AttackCommand,
    [property: JsonPropertyName("cmdpars")]
    string? CommandParameters,
    [property: JsonPropertyName("hashlistId")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    int? HashlistId,
    [property: JsonPropertyName("bench")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    int? Bench,
    [property: JsonPropertyName("statustimer")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    int? StatusTimer,
    [property: JsonPropertyName("benchType")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? BenchType,
    [property: JsonPropertyName("crackerId")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    int? CrackerId,
    [property: JsonPropertyName("hashlistAlias")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? HashlistAlias,
    [property: JsonPropertyName("files")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    IReadOnlyList<string>? Files,
    [property: JsonPropertyName("keyspace")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    ulong? Keyspace,
    [property: JsonPropertyName("usePreprocessor")]
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    bool? UsePreprocessor,
    [property: JsonPropertyName("preprocessor")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    int? PreprocessorId,
    [property: JsonPropertyName("preprocessorCommand")]
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? PreprocessorCommand,
    [property: JsonPropertyName("enforcePipe")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    bool? EnforcePipe,
    [property: JsonPropertyName("slowHash")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    bool? SlowHash,
    [property: JsonPropertyName("useBrain")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    bool? UseBrain,
    [property: JsonPropertyName("brainHost")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? BrainHost,
    [property: JsonPropertyName("brainPort")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    int? BrainPort,
    [property: JsonPropertyName("brainPass")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? BrainPassword,
    [property: JsonPropertyName("brainFeatures")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    int? BrainFeatures,
    [property: JsonPropertyName("reason")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? Reason,
    [property: JsonPropertyName("message")] [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    string? Message = null
) : IHashtopolisMessage;
