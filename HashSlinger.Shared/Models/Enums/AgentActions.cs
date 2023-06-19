namespace HashSlinger.Shared.Models.Enums;

/// <summary>Possible actions that can be performed by an agent.</summary>
public enum AgentActions
{
    /// <summary>Unknown action.</summary>
    Unknown,

    /// <summary>Registered an agent with the server.</summary>
    Register,

    /// <summary>Logged in to the server.</summary>
    Login,

    /// <summary>Updated the agent's information.</summary>
    UpdateClientInformation,

    /// <summary>Checked if the client version is up to date.</summary>
    CheckClientVersion,

    /// <summary>Downloaded a binary.</summary>
    DownloadBinary,

    /// <summary>Error on the client.</summary>
    ClientError,

    /// <summary>Got a file from the server.</summary>
    GetFile,

    /// <summary>Got a hashlist from the server.</summary>
    GetHashlist,

    /// <summary>Got a task from the server.</summary>
    GetTask,

    /// <summary>Got a chunk from the server.</summary>
    GetChunk,

    /// <summary>Sent the keyspace for a task to the server.</summary>
    SendKeyspace,

    /// <summary>Sent the progress on a task to the server.</summary>
    SendProgress,

    /// <summary>Tested the connection to the server.</summary>
    TestConnection,

    /// <summary>Got the status of a file from the server.</summary>
    GetFileStatus,

    /// <summary>Got a health check task from the server.</summary>
    GetHealthCheck,

    /// <summary>Sent the result of a health check task to the server.</summary>
    SendHealthCheck,

    /// <summary>Got a list of found hashes from the server.</summary>
    GetFound,

    /// <summary>Removed the agent from the server.</summary>
    Deregister
}
