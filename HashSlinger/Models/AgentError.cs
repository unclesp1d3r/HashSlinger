﻿namespace HashSlinger.Api.Models;

using System.ComponentModel.DataAnnotations.Schema;

/// <summary>An error event from an agent.</summary>
/// <autogeneratedoc />
public class AgentError
{
    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    /// <autogeneratedoc />
    public int Id { get; set; }

    /// <summary>Gets or sets the agent identifier.</summary>
    /// <value>The agent identifier.</value>
    /// <autogeneratedoc />
    public int AgentId { get; set; }

    /// <summary>Gets or sets the task identifier.</summary>
    /// <value>The task identifier.</value>
    /// <autogeneratedoc />
    public int? TaskId { get; set; }

    /// <summary>Gets or sets the time.</summary>
    /// <value>The time.</value>
    /// <autogeneratedoc />
    public DateTime Time { get; set; }

    /// <summary>Gets or sets the error.</summary>
    /// <value>The error.</value>
    /// <autogeneratedoc />
    public string Error { get; set; } = null!;

    /// <summary>Gets or sets the chunk identifier.</summary>
    /// <value>The chunk identifier.</value>
    /// <autogeneratedoc />
    public int? ChunkId { get; set; }

    /// <summary>Gets or sets the agent.</summary>
    /// <value>The agent.</value>
    /// <autogeneratedoc />
    [ForeignKey("AgentId")]
    [InverseProperty("AgentErrors")]
    public virtual Agent Agent { get; set; } = null!;

    /// <summary>Gets or sets the task.</summary>
    /// <value>The task.</value>
    /// <autogeneratedoc />
    [ForeignKey("TaskId")]
    [InverseProperty("AgentErrors")]
    public virtual Task? Task { get; set; }
}
