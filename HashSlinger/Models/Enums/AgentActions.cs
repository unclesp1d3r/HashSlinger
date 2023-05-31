namespace HashSlinger.Api.Models.Enums;

/// <summary>Possible actions that can be performed by an agent.</summary>
public enum AgentActions
{
    Unknown,
    Register,
    Login,
    UpdateClientInformation,
    CheckClientVersion,
    DownloadBinary,
    ClientError,
    GetFile,
    GetHashlist,
    GetTask,
    GetChunk,
    SendKeyspace,
    SendProgress,
    TestConnection,
    GetFileStatus,
    GetHealthCheck,
    SendHealthCheck,
    GetFound,
    Deregister
}
