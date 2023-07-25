namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using MediatR;

/// <summary>
///     If the client needs a file for running a task (Wordlist or Rule File) he needs to request the url for
///     downloading it.
/// </summary>
public record GetFileRequest(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("token")] string Token,
    [property: JsonPropertyName("taskId")] int TaskId,
    [property: JsonPropertyName("file")] string FileName
) : IHashtopolisRequest, IRequest<GetFileResponse>;
