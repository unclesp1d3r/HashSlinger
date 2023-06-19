namespace HashSlinger.Shared.Models.Enums;

/// <summary>Represents the status of a health check.</summary>
public enum HealthCheckStatus
{
    /// <summary>The health check is pending.</summary>
    Pending,

    /// <summary>The health check has been completed.</summary>
    Completed,

    /// <summary>The health check has failed.</summary>
    Failed,

    /// <summary>The health check has been aborted.</summary>
    Aborted
}
