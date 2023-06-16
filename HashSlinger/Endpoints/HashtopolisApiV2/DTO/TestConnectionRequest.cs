namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using MediatR;

/// <summary>Represents a request to test the connection to the Hashtopolis server.</summary>
/// <seealso cref="HashSlinger.Api.Endpoints.HashtopolisApiV2.IHashtopolisRequest" />
/// <seealso cref="HashSlinger.Api.Endpoints.HashtopolisApiV2.IHashtopolisMessage" />
/// <seealso cref="MediatR.IRequest&lt;HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO.TestConnectionResponse&gt;" />
/// <seealso cref="MediatR.IBaseRequest" />
/// <seealso cref="System.IEquatable&lt;HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO.TestConnectionRequest&gt;" />
public record TestConnectionRequest
    ([property: JsonPropertyName("action")] string Action) : IHashtopolisRequest,
        IRequest<TestConnectionResponse>;
