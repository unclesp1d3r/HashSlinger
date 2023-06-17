namespace HashSlinger.Api.Models.Enums;

using System.Diagnostics.CodeAnalysis;

/// <summary>Possible operating system values for agents.</summary>
[SuppressMessage("ReSharper", "InconsistentNaming")]
public enum AgentOperatingSystems
{
    /// <summary>Unknown Operating System</summary>
    Unknown = -1,

    /// <summary>Linux or Unix based Operating System</summary>
    Linux = 0,

    /// <summary>Microsoft Windows Operating System</summary>
    Windows = 1,

    /// <summary>Apple macOS Operating System or Darwin</summary>
    MacOS = 2
}
