﻿namespace HashSlinger.Api.Models;

using System.ComponentModel.DataAnnotations;

/// <summary>Stores the output of a task.</summary>
/// <autogeneratedoc />
public record TaskDebugOutput
{
    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    /// <autogeneratedoc />
    public int Id { get; set; }

    /// <summary>Gets or sets the task identifier.</summary>
    /// <value>The task identifier.</value>
    /// <autogeneratedoc />
    public int TaskId { get; set; }

    /// <summary>Gets or sets the output.</summary>
    /// <value>The output.</value>
    /// <autogeneratedoc />
    [StringLength(256)]
    public string Output { get; set; } = null!;

    /// <summary>Gets or sets the task.</summary>
    /// <value>The task.</value>
    /// <autogeneratedoc />
    public virtual Task Task { get; set; } = null!;
}
