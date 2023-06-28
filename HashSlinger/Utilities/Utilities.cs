namespace HashSlinger.Api.Utilities;

using Shared.Models.Enums;

/// <summary>General utilities.</summary>
public static class Utilities
{
    /// <summary>Gets the correct file extension for the agent operating system.</summary>
    /// <param name="agentOS">The agent os.</param>
    /// <returns>The correct executable extension for the agent's operating system.</returns>
    /// <exception cref="System.ArgumentOutOfRangeException">validAgentOperatingSystem - null</exception>
    public static string GetFileExtension(AgentOperatingSystems agentOS)
    {
        return agentOS switch
        {
            AgentOperatingSystems.Windows => ".exe",
            AgentOperatingSystems.Linux => ".bin",
            AgentOperatingSystems.MacOS => ".bin",
            AgentOperatingSystems.Unknown => string.Empty,
            _ => throw new ArgumentOutOfRangeException(nameof(agentOS), agentOS, null)
        };
    }
}
