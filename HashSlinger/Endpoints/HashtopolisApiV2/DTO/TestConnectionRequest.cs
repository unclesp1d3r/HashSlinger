namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;

/// <inheritdoc />
public record TestConnectionRequest
    ([property: JsonPropertyName("action")] string Action) : IHashtopolisRequest
{
    public IHashtopolisMessage ProcessRequest()
    {
        return new TestConnectionResponse("testConnection", "SUCCESS");
    }
}
