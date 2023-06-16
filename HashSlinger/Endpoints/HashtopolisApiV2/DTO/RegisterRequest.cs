namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using MediatR;

/// <summary>Sent by the client when registering a new client to the server</summary>
public record RegisterRequest(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("voucher")]
    string Voucher,
    [property: JsonPropertyName("name")] string Name
) : IHashtopolisRequest, IRequest<RegisterResponse>;
