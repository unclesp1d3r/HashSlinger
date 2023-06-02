namespace HashSlinger.Api.Models.Enums;

/// <summary>Possible operating system values for agents.</summary>
public enum AgentOperatingSystems
{
    /// <summary>Unknown Operating System</summary>
    Unknown = -1,

    /// <summary>Linux or Unix based Operating System</summary>
    Linux = 0,

    /// <summary>Microsoft Windows Operating System</summary>
    Windows = 1,

    /// <summary>Apple macOS Operating System or Darwin</summary>
    macOS = 2
}
