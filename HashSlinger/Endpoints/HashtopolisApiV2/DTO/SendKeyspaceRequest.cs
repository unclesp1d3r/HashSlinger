namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using DAL;

/// <summary>The client sends the calculated keyspace of a task.<br /></summary>
public record SendKeyspaceRequest(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("token")] string Token,
    [property: JsonPropertyName("taskId")] int TaskId,
    [property: JsonPropertyName("keyspace")]
    ulong Keyspace
) : IHashtopolisRequest
{
    /// <inheritdoc />
    public Task<IHashtopolisMessage> ProcessRequestAsync(Repository repository)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public IHashtopolisMessage ProcessRequest()
    {
        throw new NotImplementedException();
    }
}
