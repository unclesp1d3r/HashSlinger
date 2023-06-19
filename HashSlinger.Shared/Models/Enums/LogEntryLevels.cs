namespace HashSlinger.Shared.Models.Enums;

/// <summary>Log entry severity levels used to classify log messages.</summary>
public enum LogEntryLevels
{
    /// <summary>
    ///     Trace level messages are designed to output fine-grained diagnostic events. This is the lowest level of
    ///     severity and can include high-volume information such as protocol payloads. These messages are mostly
    ///     used for debugging and may not be necessary in a production environment.
    /// </summary>
    Trace,

    /// <summary>
    ///     Debug level log messages provide more detailed information than Trace level for the purpose of diagnosing
    ///     issues. These messages are also used for debugging and generally not needed in a production environment.
    /// </summary>
    Debug,

    /// <summary>
    ///     Information level log messages are used to track the general flow of the application. These logs should
    ///     be used for information that may be needed in production environments.
    /// </summary>
    Information,

    /// <summary>
    ///     Warning level log messages are used to highlight abnormal or unexpected events in the application flow.
    ///     These may not lead to application failure but require attention as they might indicate problems.
    /// </summary>
    Warning,

    /// <summary>
    ///     Error level log messages highlight when the current flow of execution is stopped due to a failure. These
    ///     should indicate a failure in the current activity or operation (such as an HTTP request or a background
    ///     task).
    /// </summary>
    Error,

    /// <summary>
    ///     Fatal level log messages denote severe errors that cause a premature application failure. These are
    ///     critical issues, and the application may possibly be unable to recover from these failures.
    /// </summary>
    Fatal
}
