namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using DAL;

/// <summary>The client sends the tested benchmark of a task.</summary>
/// <remarks>
///     Benchmark type can be 'speed' or 'run'. If the 'speed' benchmark type is used, there are two values to be
///     sent separated by ':'. The 'speed' benchmark type is using the –progress-only switch of hashcat. The
///     'run' benchmark type uses the old method of Hashtopolis to benchmark a task in running the given task for
///     some time
/// </remarks>
public record SendBenchmarkRequest(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("token")] string Token,
    [property: JsonPropertyName("taskId")] int? TaskId,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("result")] string Result
) : IHashtopolisRequest
{
    /// <inheritdoc />
    public Task<IHashtopolisMessage> ProcessRequestAsync(Repository repository)
    {
        throw new NotImplementedException();
    }
}
