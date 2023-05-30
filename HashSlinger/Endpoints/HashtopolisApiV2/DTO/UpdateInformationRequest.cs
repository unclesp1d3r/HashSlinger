namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using DAL;

/// <summary>Sent by the client to send information about the client operating system and the available hardware.</summary>
public record UpdateInformationRequest(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("token")] string Token,
    [property: JsonPropertyName("uid")] string Uid,
    [property: JsonPropertyName("os")] int? Os,
    [property: JsonPropertyName("devices")]
    IReadOnlyList<string> Devices
) : IHashtopolisRequest
{
    /// <inheritdoc />
    public IHashtopolisMessage ProcessRequest()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<IHashtopolisMessage> ProcessRequestAsync(IHashSlingerRepository repository)
    {
        throw new NotImplementedException();
    }
}
