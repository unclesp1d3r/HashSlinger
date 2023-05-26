﻿namespace HashSlinger.Api.Endpoints.HashtopolisApiV2;

using System.Text.Json.Serialization;
using DTO;

/// <summary>A big, ugly DTO object to be able to deserialize the initial request from a Hashtopolis client into the appropriate DTO object.</summary>
/// <autogeneratedoc />
/// <remarks>This thing is a mess and I welcome ideas on how to clean it up.</remarks>
public record HashtopolisRequest : IHashtopolisMessage
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HashtopolisRequest"/> class.
    /// </summary>
    public HashtopolisRequest() : this(null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="HashtopolisRequest"/> class.
    /// </summary>
    /// <param name="Action">The action.</param>
    public HashtopolisRequest(string Action) : this(Action,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null) =>
        this.Action = Action!;

    /// <summary>A big, ugly DTO object to be able to deserialize the initial request from a Hashtopolis client into the appropriate DTO object.</summary>
    /// <autogeneratedoc />
    public HashtopolisRequest(
        string? Action,
        string? Voucher,
        string? Name,
        string? Token,
        string? Uid,
        int? Os,
        IReadOnlyList<string>? Devices,
        string? ClientSignature,
        string? Version,
        int? PreprocessorId,
        int? BinaryVersionId,
        string? Message,
        string? File,
        int? HashlistId,
        int? TaskId,
        string? Type,
        string? Result,
        int? ChunkId,
        int? KeyspaceProgress,
        string? RelativeProgress,
        int? Speed,
        int? State,
        IReadOnlyList<List<string>?>? Cracks,
        IReadOnlyList<int>? GpuTemp,
        IReadOnlyList<int>? GpuUtil,
        int? NumCracked,
        int? Start,
        int? End,
        int? NumGpus,
        IReadOnlyList<string>? Errors,
        int? CheckId,
        ulong? Keyspace
    )
    {
        this.Action = Action;
        this.Voucher = Voucher;
        this.Name = Name;
        this.Token = Token;
        this.Uid = Uid;
        this.Os = Os;
        this.Devices = Devices;
        this.ClientSignature = ClientSignature;
        this.Version = Version;
        this.PreprocessorId = PreprocessorId;
        this.BinaryVersionId = BinaryVersionId;
        this.Message = Message;
        this.File = File;
        this.HashlistId = HashlistId;
        this.TaskId = TaskId;
        this.Type = Type;
        this.Result = Result;
        this.ChunkId = ChunkId;
        this.KeyspaceProgress = KeyspaceProgress;
        this.RelativeProgress = RelativeProgress;
        this.Speed = Speed;
        this.State = State;
        this.Cracks = Cracks;
        this.GpuTemp = GpuTemp;
        this.GpuUtil = GpuUtil;
        this.NumCracked = NumCracked;
        this.Start = Start;
        this.End = End;
        this.NumGpus = NumGpus;
        this.Errors = Errors;
        this.CheckId = CheckId;
        this.Keyspace = Keyspace;
    }

    /// <summary>Gets the action.</summary>
    /// <value>The action.</value>
    [JsonPropertyName("action")]
    public string? Action { get; init; }

    /// <summary>Gets the voucher.</summary>
    /// <value>The voucher.</value>
    [JsonPropertyName("voucher")]
    public string? Voucher { get; init; }

    /// <summary>Gets the name.</summary>
    /// <value>The name.</value>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>Gets the token.</summary>
    /// <value>The token.</value>
    [JsonPropertyName("token")]
    public string? Token { get; init; }

    /// <summary>Gets the uid.</summary>
    /// <value>The uid.</value>
    [JsonPropertyName("uid")]
    public string? Uid { get; init; }

    /// <summary>Gets the OS.</summary>
    /// <value>The os.</value>
    [JsonPropertyName("os")]
    public int? Os { get; init; }

    /// <summary>Gets the devices.</summary>
    /// <value>The devices.</value>
    [JsonPropertyName("devices")]
    public IReadOnlyList<string>? Devices { get; init; }

    /// <summary>Gets the client signature.</summary>
    /// <value>The client signature.</value>
    [JsonPropertyName("clientSignature")]
    public string? ClientSignature { get; init; }

    /// <summary>Gets the version.</summary>
    /// <value>The version.</value>
    [JsonPropertyName("version")]
    public string? Version { get; init; }

    /// <summary>Gets the preprocessor identifier.</summary>
    /// <value>The preprocessor identifier.</value>
    [JsonPropertyName("preprocessorId")]
    public int? PreprocessorId { get; init; }

    /// <summary>Gets the binary version identifier.</summary>
    /// <value>The binary version identifier.</value>
    [JsonPropertyName("binaryVersionId")]
    public int? BinaryVersionId { get; init; }

    /// <summary>Gets the message.</summary>
    /// <value>The message.</value>
    [JsonPropertyName("message")]
    public string? Message { get; init; }

    /// <summary>Gets the file.</summary>
    /// <value>The file.</value>
    [JsonPropertyName("file")]
    public string? File { get; init; }

    /// <summary>Gets the hashlist identifier.</summary>
    /// <value>The hashlist identifier.</value>
    [JsonPropertyName("hashlistId")]
    public int? HashlistId { get; init; }

    /// <summary>Gets the task identifier.</summary>
    /// <value>The task identifier.</value>
    [JsonPropertyName("taskId")]
    public int? TaskId { get; init; }

    /// <summary>Gets the type.</summary>
    /// <value>The type.</value>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>Gets the result.</summary>
    /// <value>The result.</value>
    [JsonPropertyName("result")]
    public string? Result { get; init; }

    /// <summary>Gets the chunk identifier.</summary>
    /// <value>The chunk identifier.</value>
    [JsonPropertyName("chunkId")]
    public int? ChunkId { get; init; }

    /// <summary>Gets the keyspace progress.</summary>
    /// <value>The keyspace progress.</value>
    [JsonPropertyName("keyspaceProgress")]
    public int? KeyspaceProgress { get; init; }

    /// <summary>Gets the relative progress.</summary>
    /// <value>The relative progress.</value>
    [JsonPropertyName("relativeProgress")]
    public string? RelativeProgress { get; init; }

    /// <summary>Gets the speed.</summary>
    /// <value>The speed.</value>
    [JsonPropertyName("speed")]
    public int? Speed { get; init; }

    /// <summary>Gets the state.</summary>
    /// <value>The state.</value>
    [JsonPropertyName("state")]
    public int? State { get; init; }

    /// <summary>Gets the cracks.</summary>
    /// <value>The cracks.</value>
    [JsonPropertyName("cracks")]
    public IReadOnlyList<List<string>?>? Cracks { get; init; }

    /// <summary>Gets the gpu temporary.</summary>
    /// <value>The gpu temporary.</value>
    [JsonPropertyName("gpuTemp")]
    public IReadOnlyList<int>? GpuTemp { get; init; }

    /// <summary>Gets the gpu utility.</summary>
    /// <value>The gpu utility.</value>
    [JsonPropertyName("gpuUtil")]
    public IReadOnlyList<int>? GpuUtil { get; init; }

    /// <summary>Gets the number cracked.</summary>
    /// <value>The number cracked.</value>
    [JsonPropertyName("numCracked")]
    public int? NumCracked { get; init; }

    /// <summary>Gets the start.</summary>
    /// <value>The start.</value>
    [JsonPropertyName("start")]
    public int? Start { get; init; }

    /// <summary>Gets the end.</summary>
    /// <value>The end.</value>
    [JsonPropertyName("end")]
    public int? End { get; init; }

    /// <summary>Gets the number gpus.</summary>
    /// <value>The number gpus.</value>
    [JsonPropertyName("numGpus")]
    public int? NumGpus { get; init; }

    /// <summary>Gets the errors.</summary>
    /// <value>The errors.</value>
    [JsonPropertyName("errors")]
    public IReadOnlyList<string>? Errors { get; init; }

    /// <summary>Gets the check identifier.</summary>
    /// <value>The check identifier.</value>
    [JsonPropertyName("checkId")]
    public int? CheckId { get; init; }

    /// <summary>Gets the keyspace.</summary>
    /// <value>The keyspace.</value>
    [JsonPropertyName("keyspace")]
    public ulong? Keyspace { get; init; }

    /// <summary>Attempts to convert to a more specific form of IHashtopolisRequest.</summary>
    /// <returns>Specific implementation of IHashtopolisRequest, or null if not possible.</returns>
    /// <remarks>Some of these null checks might be wrong, or should return other errors.
    /// This will need constant attention as I finish out the API.</remarks>
    public IHashtopolisRequest? ToHashtopolisRequest()
    {
        if (Action == null) return null;
        switch (Action)
        {
            case "testConnection":
                return new TestConnectionRequest(Action!);
            case "register":
                return Voucher != null && Name != null ? new RegisterRequest(Action!, Voucher, Name) : null;
            case "updateInformation":
                return Token != null && Uid != null && Devices != null
                    ? new UpdateInformationRequest(Action!, Token, Uid, Os, Devices)
                    : null;

            case "login":
                return ClientSignature != null && Token != null
                    ? new LoginRequest(Action!, ClientSignature, Token)
                    : null;

            case "checkClientVersion":
                return Version != null && Type != null && Token != null
                    ? new CheckClientVersionRequest(Action!, Version, Type, Token)
                    : null;

            case "downloadBinary":
                return Type != null && Token != null
                    ? new DownloadBinaryRequest(Action!, Type, PreprocessorId, Token, BinaryVersionId)
                    : null;

            case "clientError":
                return Token != null && Message != null
                    ? new ClientErrorRequest(Action!, TaskId, Token, ChunkId, Message)
                    : null;

            case "getFile":
                return Token != null && File != null
                    ? new GetFileRequest(Action!, Token, TaskId, File)
                    : null;
            case "getHashlist":
                return Token != null && HashlistId != null && Action != null
                    ? new GetHashlistRequest(Action!, Token, HashlistId.GetValueOrDefault())
                    : null;

            case "getTask":
                return Token != null ? new GetTaskRequest(Action!, Token) : null;
            case "getChunk":
                return Token != null && TaskId != null ? new GetChunkRequest(Action!, Token, TaskId) : null;

            case "sendKeyspace":
                return Token != null && TaskId != null && Keyspace != null
                    ? new SendKeyspaceRequest(Action!,
                        Token,
                        TaskId.GetValueOrDefault(),
                        Keyspace.GetValueOrDefault())
                    : null;

            case "sendBenchmark":
                return Token != null && TaskId != null && Type != null && Result != null
                    ? new SendBenchmarkRequest(Action!, Token, TaskId, Type, Result)
                    : null;

            case "sendProgress":
                return Token != null
                       && ChunkId != null
                       && KeyspaceProgress != null
                       && RelativeProgress != null
                       && Speed != null
                       && State != null
                       && Cracks != null
                       && GpuTemp != null
                       && GpuUtil != null
                    ? new SendProgressRequest(Action!,
                        Token,
                        ChunkId,
                        KeyspaceProgress,
                        RelativeProgress,
                        Speed,
                        State,
                        Cracks!,
                        GpuTemp,
                        GpuUtil)
                    : null;

            case "getFileStatus":
                return Token != null ? new GetFileStatusRequest(Action!, Token) : null;
            case "getHealthCheck":
                return Token != null ? new GetHealthCheckRequest(Action!, Token) : null;
            case "SendHealthCheck":
                return Token != null
                       && NumCracked != null
                       && Start != null
                       && End != null
                       && NumGpus != null
                       && Errors != null
                       && CheckId != null
                    ? new SendHealthCheckRequest(Action!,
                        Token,
                        NumCracked,
                        Start,
                        End,
                        NumGpus,
                        Errors,
                        CheckId)
                    : null;

            case "deregister":
                return Token != null ? new DeregisterRequest(Action!, Token) : null;
            default:
                return null;
        }
    }

    /// <summary>
    /// Deconstructs the specified action.
    /// </summary>
    /// <param name="Action">The action.</param>
    /// <param name="Voucher">The voucher.</param>
    /// <param name="Name">The name.</param>
    /// <param name="Token">The token.</param>
    /// <param name="Uid">The uid.</param>
    /// <param name="Os">The os.</param>
    /// <param name="Devices">The devices.</param>
    /// <param name="ClientSignature">The client signature.</param>
    /// <param name="Version">The version.</param>
    /// <param name="PreprocessorId">The preprocessor identifier.</param>
    /// <param name="BinaryVersionId">The binary version identifier.</param>
    /// <param name="Message">The message.</param>
    /// <param name="File">The file.</param>
    /// <param name="HashlistId">The hashlist identifier.</param>
    /// <param name="TaskId">The task identifier.</param>
    /// <param name="Type">The type.</param>
    /// <param name="Result">The result.</param>
    /// <param name="ChunkId">The chunk identifier.</param>
    /// <param name="KeyspaceProgress">The keyspace progress.</param>
    /// <param name="RelativeProgress">The relative progress.</param>
    /// <param name="Speed">The speed.</param>
    /// <param name="State">The state.</param>
    /// <param name="Cracks">The cracks.</param>
    /// <param name="GpuTemp">The gpu temporary.</param>
    /// <param name="GpuUtil">The gpu utility.</param>
    /// <param name="NumCracked">The number cracked.</param>
    /// <param name="Start">The start.</param>
    /// <param name="End">The end.</param>
    /// <param name="NumGpus">The number gpus.</param>
    /// <param name="Errors">The errors.</param>
    /// <param name="CheckId">The check identifier.</param>
    /// <param name="Keyspace">The keyspace.</param>
    public void Deconstruct(
        out string? Action,
        out string? Voucher,
        out string? Name,
        out string? Token,
        out string? Uid,
        out int? Os,
        out IReadOnlyList<string>? Devices,
        out string? ClientSignature,
        out string? Version,
        out int? PreprocessorId,
        out int? BinaryVersionId,
        out string? Message,
        out string? File,
        out int? HashlistId,
        out int? TaskId,
        out string? Type,
        out string? Result,
        out int? ChunkId,
        out int? KeyspaceProgress,
        out string? RelativeProgress,
        out int? Speed,
        out int? State,
        out IReadOnlyList<List<string>?>? Cracks,
        out IReadOnlyList<int>? GpuTemp,
        out IReadOnlyList<int>? GpuUtil,
        out int? NumCracked,
        out int? Start,
        out int? End,
        out int? NumGpus,
        out IReadOnlyList<string>? Errors,
        out int? CheckId,
        out ulong? Keyspace
    )
    {
        Action = this.Action;
        Voucher = this.Voucher;
        Name = this.Name;
        Token = this.Token;
        Uid = this.Uid;
        Os = this.Os;
        Devices = this.Devices;
        ClientSignature = this.ClientSignature;
        Version = this.Version;
        PreprocessorId = this.PreprocessorId;
        BinaryVersionId = this.BinaryVersionId;
        Message = this.Message;
        File = this.File;
        HashlistId = this.HashlistId;
        TaskId = this.TaskId;
        Type = this.Type;
        Result = this.Result;
        ChunkId = this.ChunkId;
        KeyspaceProgress = this.KeyspaceProgress;
        RelativeProgress = this.RelativeProgress;
        Speed = this.Speed;
        State = this.State;
        Cracks = this.Cracks;
        GpuTemp = this.GpuTemp;
        GpuUtil = this.GpuUtil;
        NumCracked = this.NumCracked;
        Start = this.Start;
        End = this.End;
        NumGpus = this.NumGpus;
        Errors = this.Errors;
        CheckId = this.CheckId;
        Keyspace = this.Keyspace;
    }
}
