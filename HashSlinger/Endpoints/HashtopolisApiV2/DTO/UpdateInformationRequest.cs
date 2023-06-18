namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Net;
using System.Text.Json.Serialization;
using MediatR;

/// <summary>Sent by the client to send information about the client operating system and the available hardware.</summary>
public record UpdateInformationRequest(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("token")] string Token,
    [property: JsonPropertyName("uid")] string Uid,
    [property: JsonPropertyName("os")] int OperatingSystem,
    [property: JsonPropertyName("devices")]
    ICollection<string> Devices,
    [property: JsonIgnore] IPAddress? IpAddress
) : IHashtopolisRequest, IRequest<UpdateInformationResponse>;
