namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using MediatR;

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
) : IHashtopolisRequest, IRequest<DownloadBinaryResponse>;
