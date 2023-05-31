namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using Data;

/// <summary>
///     This command is used to either download the 7z binary to extract Hashcat, Preprocessors, or to get
///     information where to download the newest Hashcat/Cracker version and some additional informations about
///     it.
/// </summary>
public record DownloadBinaryRequest(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("preprocessorId")]
    int? PreprocessorId,
    [property: JsonPropertyName("token")] string Token,
    [property: JsonPropertyName("binaryVersionId")]
    int? BinaryVersionId
) : IHashtopolisRequest
{
    /// <inheritdoc />
    public Task<IHashtopolisMessage> ProcessRequestAsync(HashSlingerContext db, ILogger logger)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public IHashtopolisMessage ProcessRequest()
    {
        throw new NotImplementedException();
    }
}
