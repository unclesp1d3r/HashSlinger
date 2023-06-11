namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using DAL;
using Mapster;
using Models;

/// <summary>
///     This command is used to either download the 7z binary to extract Hashcat, Preprocessors, or to get
///     information where to download the newest Hashcat/Cracker version and some additional information about
///     it.
/// </summary>
/// <remarks>
///     <para>This API call is just a mess. </para>
///     <para>
///         It's not clear what the "type" parameter is supposed to be. So it just gets to be a big, messy switch
///         statement.
///     </para>
/// </remarks>
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
    public async Task<IHashtopolisMessage> ProcessRequestAsync(Repository repository)
    {
        Agent? agent = await repository.GetAgentByTokenAsync(Token).ConfigureAwait(true);
        if (agent == null)
            return this.Adapt<DownloadBinaryResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Invalid token"
            };

        // This is the best I can come up with, given how weird the Hashtopolis API is.
        switch (Type)
        {
            case "7zr":
                DownloadableBinary? sevenZipBinary
                    = await repository.GetBinaryAsync("7zr").ConfigureAwait(true);
                if (sevenZipBinary == null)
                    return this.Adapt<DownloadBinaryResponse>() with
                    {
                        Response = HashtopolisConstants.ErrorResponse,
                        Message = "7zr binary not found"
                    };
                return this.Adapt<DownloadBinaryResponse>() with
                {
                    Response = HashtopolisConstants.SuccessResponse,
                    Url = sevenZipBinary.DownloadUrl
                };
                break;
            case "preprocessor":
                return this.Adapt<DownloadBinaryResponse>() with
                {
                    Response = HashtopolisConstants.SuccessResponse,
                    Message = $"Requested binary type: {Type}"
                };
                break;
            case "cracker":
                return this.Adapt<DownloadBinaryResponse>() with
                {
                    Response = HashtopolisConstants.SuccessResponse,
                    Message = $"Requested binary type: {Type}"
                };
                break;
            default:
                return this.Adapt<DownloadBinaryResponse>() with
                {
                    Response = HashtopolisConstants.ErrorResponse,
                    Message = $"Unknown binary type: {Type}"
                };
        }
    }
}
