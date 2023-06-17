namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using MediatR;

/// <summary>
///     The client can request a list of deleted filenames from the server to be able to clean up unused
///     files.
/// </summary>
public record GetFileStatusRequest(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("token")] string Token
) : IHashtopolisRequest, IRequest<GetFileStatusResponse>;
