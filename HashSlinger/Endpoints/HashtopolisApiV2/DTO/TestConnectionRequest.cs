namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;
/// <inheritdoc />
public record TestConnectionRequest
    ([property: JsonPropertyName("action")] string Action) : IHashtopolisRequest
{
    /// <inheritdoc />
    public async Task<IHashtopolisMessage> ProcessRequestAsync(IHashSlingerRepository repository)
    {
        return new TestConnectionResponse("testConnection", "SUCCESS");
    }
}
