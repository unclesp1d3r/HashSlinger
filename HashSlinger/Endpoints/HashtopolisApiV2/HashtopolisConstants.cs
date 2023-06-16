namespace HashSlinger.Api.Endpoints.HashtopolisApiV2;

/// <summary>String constants relevant to the Hashtopolis API</summary>
public static class HashtopolisConstants
{
    /// <summary>The version string returned when a ClientVersionCheck has the current version.</summary>
    public const string ClientVersionCheckCurrent = "OK";

    /// <summary>The version string returned when a ClientVersionCheck has an updated client version.</summary>
    public const string ClientVersionCheckUpdateAvailable = "NEW";

    /// <summary>The download end point prefix</summary>
    public const string DownloadEndPointPrefix = "/files";

    /// <summary>The URL prefix for the Hashtopolis API endpoint.</summary>
    public const string EndPointPrefix = "/api/Hashtopolis";

    /// <summary>The error response</summary>
    public const string ErrorResponse = "ERROR";

    /// <summary>The success response</summary>
    public const string SuccessResponse = "SUCCESS";

    /// <summary>The upload end point prefix</summary>
    public const string UploadEndPointPrefix = "/files";
}
