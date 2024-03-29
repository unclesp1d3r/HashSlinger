﻿// ReSharper disable StringLiteralTypo

namespace HashSlinger.Api.Endpoints.HashtopolisApiV2;

using System.Text.Json.Serialization;
using DTO;
using Mapster;

/// <summary>
///     A big, ugly DTO object to be able to deserialize the initial request from a Hashtopolis client into the
///     appropriate DTO object.
/// </summary>
/// <autogeneratedoc />
/// <remarks>This thing is a mess and I welcome ideas on how to clean it up.</remarks>
public record HashtopolisRequest(
    [property: JsonPropertyName("action")] string? Action = default,
    [property: JsonPropertyName("voucher")]
    string? Voucher = default,
    [property: JsonPropertyName("name")] string? Name = default,
    [property: JsonPropertyName("token")] string? Token = default,
    [property: JsonPropertyName("uid")] string? Uid = default,
    [property: JsonPropertyName("os")] int? OperatingSystem = default,
    [property: JsonPropertyName("devices")]
    ICollection<string>? Devices = default,
    [property: JsonPropertyName("clientSignature")]
    string? ClientSignature = default,
    [property: JsonPropertyName("version")]
    string? Version = default,
    [property: JsonPropertyName("preprocessorId")]
    int? PreprocessorId = default,
    [property: JsonPropertyName("binaryVersionId")]
    int? BinaryVersionId = default,
    [property: JsonPropertyName("message")]
    string? Message = default,
    [property: JsonPropertyName("file")] string? FileName = default,
    [property: JsonPropertyName("hashlistId")]
    int? HashlistId = default,
    [property: JsonPropertyName("taskId")] int? TaskId = default,
    [property: JsonPropertyName("type")] string? Type = default,
    [property: JsonPropertyName("result")] string? Result = default,
    [property: JsonPropertyName("chunkId")]
    int? ChunkId = default,
    [property: JsonPropertyName("keyspaceProgress")]
    int? KeyspaceProgress = default,
    [property: JsonPropertyName("relativeProgress")]
    string? RelativeProgress = default,
    [property: JsonPropertyName("speed")] int? Speed = default,
    [property: JsonPropertyName("state")] int? State = default,
    [property: JsonPropertyName("cracks")] ICollection<ICollection<string>?>? Cracks = default,
    [property: JsonPropertyName("gpuTemp")]
    ICollection<int>? GpuTemp = default,
    [property: JsonPropertyName("gpuUtil")]
    ICollection<int>? GpuUtil = default,
    [property: JsonPropertyName("numCracked")]
    int? NumCracked = default,
    [property: JsonPropertyName("start")] ulong? Start = default,
    [property: JsonPropertyName("end")] ulong? End = default,
    [property: JsonPropertyName("numGpus")]
    int? NumGpus = default,
    [property: JsonPropertyName("errors")] ICollection<string>? Errors = default,
    [property: JsonPropertyName("checkId")]
    int? CheckId = default,
    [property: JsonPropertyName("keyspace")]
    ulong? Keyspace = default,
    [property: JsonPropertyName("response")]
    string? Response = default
) : IHashtopolisMessage
{
    /// <summary>Converts to a specific IHashtopolisRequest implementation.</summary>
    /// <param name="request">The request.</param>
    public static IHashtopolisRequest? ToHashtopolisRequest(HashtopolisRequest? request)
    {
        if (request == null) return null;
        return request.Action?.ToLower() switch
        {
            "testconnection" => request.Adapt<TestConnectionRequest>(),
            "register" => request.Adapt<RegisterRequest>(),
            "updateinformation" => request.Adapt<UpdateInformationRequest>(),
            "login" => request.Adapt<LoginRequest>(),
            "checkclientversion" => request.Adapt<CheckClientVersionRequest>(),
            "downloadbinary" => request.Adapt<DownloadBinaryRequest>(),
            "clienterror" => request.Adapt<ClientErrorRequest>(),
            "getfile" => request.Adapt<GetFileRequest>(),
            "gethashlist" => request.Adapt<GetHashlistRequest>(),
            "gettask" => request.Adapt<GetTaskRequest>(),
            "getchunk" => request.Adapt<GetChunkRequest>(),
            "sendkeyspace" => request.Adapt<SendKeyspaceRequest>(),
            "sendbenchmark" => request.Adapt<SendBenchmarkRequest>(),
            "sendprogress" => request.Adapt<SendProgressRequest>(),
            "getfilestatus" => request.Adapt<GetFileStatusRequest>(),
            "gethealthcheck" => request.Adapt<GetHealthCheckRequest>(),
            "sendhealthcheck" => request.Adapt<SendHealthCheckRequest>(),
            "deregister" => request.Adapt<DeregisterRequest>(),
            var _ => null
        };
    }
}
