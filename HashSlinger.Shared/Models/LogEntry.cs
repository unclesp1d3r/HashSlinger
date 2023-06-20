﻿namespace HashSlinger.Shared.Models;

using Enums;

/// <summary>Represents an entry in the log.</summary>
/// <autogeneratedoc />
public record LogEntry
{
    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    /// <autogeneratedoc />
    public Guid Id { get; set; }

    /// <summary>Gets or sets the issuer.</summary>
    /// <value>The issuer.</value>
    /// <autogeneratedoc />
    public string Issuer { get; set; } = null!;


    /// <summary>Gets or sets the level.</summary>
    /// <value>The level.</value>
    /// <autogeneratedoc />
    public LogEntryLevels Level { get; set; } = LogEntryLevels.Information;

    /// <summary>Gets or sets the message.</summary>
    /// <value>The message.</value>
    /// <autogeneratedoc />
    public string Message { get; set; } = null!;

    /// <summary>Gets or sets the time.</summary>
    /// <value>The time.</value>
    /// <autogeneratedoc />
    public DateTime Time { get; set; }

    /// <summary>Creates a new Debug level entry.</summary>
    /// <param name="message">The message.</param>
    /// <param name="issuer">The issuer.</param>
    /// <returns>A new LogEntry</returns>
    public static LogEntry Debug(string message, string issuer = "HashSlinger")
    {
        return LogEntry.CreateEntry(message, LogEntryLevels.Debug, issuer);
    }

    /// <summary>Creates a new Error level entry.</summary>
    /// <param name="message">The message.</param>
    /// <param name="issuer">The issuer.</param>
    /// <returns>A new LogEntry</returns>
    public static LogEntry Error(string message, string issuer = "HashSlinger")
    {
        return LogEntry.CreateEntry(message, LogEntryLevels.Error, issuer);
    }

    /// <summary>Creates a new Fatal level entry.</summary>
    /// <param name="message">The message.</param>
    /// <param name="issuer">The issuer.</param>
    /// <returns>A new LogEntry</returns>
    public static LogEntry Fatal(string message, string issuer = "HashSlinger")
    {
        return LogEntry.CreateEntry(message, LogEntryLevels.Fatal, issuer);
    }

    /// <summary>Creates a new Information level entry.</summary>
    /// <param name="message">The message.</param>
    /// <param name="issuer">The issuer.</param>
    /// <returns>A new LogEntry</returns>
    public static LogEntry Information(string message, string issuer = "HashSlinger")
    {
        return LogEntry.CreateEntry(message, LogEntryLevels.Information, issuer);
    }

    /// <summary>Creates a new Trace level entry.</summary>
    /// <param name="message">The message.</param>
    /// <param name="issuer">The issuer.</param>
    public static LogEntry Tracing(string message, string issuer = "HashSlinger")
    {
        return LogEntry.CreateEntry(message, LogEntryLevels.Trace, issuer);
    }

    /// <summary>Creates a new Warning level entry.</summary>
    /// <param name="message">The message.</param>
    /// <param name="issuer">The issuer.</param>
    /// <returns>A new LogEntry</returns>
    public static LogEntry Warning(string message, string issuer = "HashSlinger")
    {
        return LogEntry.CreateEntry(message, LogEntryLevels.Warning, issuer);
    }

    /// <summary>Creates a new entry with defaults.</summary>
    /// <param name="message">The message.</param>
    /// <param name="level">The level.</param>
    /// <param name="issuer">The issuer.</param>
    private static LogEntry CreateEntry(
        string message,
        LogEntryLevels level = LogEntryLevels.Information,
        string issuer = "HashSlinger"
    )
    {
        return new LogEntry
        {
            Id = Guid.NewGuid(),
            Time = DateTime.UtcNow,
            Issuer = issuer,
            Message = message,
            Level = level
        };
    }
}