namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using MediatR;

/// <summary>Represents a request to test the connection to the Hashtopolis server.</summary>
public record TestConnectionRequest
    ([property: JsonPropertyName("action")] string Action) : IHashtopolisRequest,
                                                             IRequest<TestConnectionResponse>;
