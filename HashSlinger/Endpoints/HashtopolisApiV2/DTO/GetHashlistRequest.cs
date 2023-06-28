namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using MediatR;

/// <summary>The client can download a Hashlist/Superhashlist</summary>
public record GetHashlistRequest(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("token")] string Token,
    [property: JsonPropertyName("hashlistId")]
    int HashlistId
) : IHashtopolisRequest, IRequest<GetHashlistResponse>;
