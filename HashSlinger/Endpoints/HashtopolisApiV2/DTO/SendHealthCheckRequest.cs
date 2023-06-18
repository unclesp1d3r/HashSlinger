// ReSharper disable StringLiteralTypo

namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using MediatR;

/// <summary>When the client executed a health check it should send back the results.</summary>
public record SendHealthCheckRequest(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("token")] string Token,
    [property: JsonPropertyName("checkId")]
    int CheckId,
    [property: JsonPropertyName("numCracked")]
    int NumCracked,
    [property: JsonPropertyName("start")] ulong Start,
    [property: JsonPropertyName("end")] ulong End,
    [property: JsonPropertyName("numGpus")]
    int NumGpus,
    [property: JsonPropertyName("errors")] ICollection<string> Errors
) : IHashtopolisRequest, IRequest<SendHealthCheckResponse>;
