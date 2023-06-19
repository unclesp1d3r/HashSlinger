﻿namespace HashSlinger.Api.Models;

using System.ComponentModel.DataAnnotations;

/// <summary>Represents a configured preprocessor tool.</summary>
/// <autogeneratedoc />
public record Preprocessor : DownloadableBinary
{
    /// <summary>Gets or sets the tasks.</summary>
    /// <value>The tasks.</value>
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    /// <summary>Gets or sets the keyspace command.</summary>
    /// <value>The keyspace command.</value>
    /// <autogeneratedoc />
    [StringLength(256)]
    public string? KeyspaceCommand { get; set; }


    /// <summary>Gets or sets the limit command.</summary>
    /// <value>The limit command.</value>
    /// <autogeneratedoc />
    [StringLength(256)]
    public string? LimitCommand { get; set; }


    /// <summary>Gets or sets the skip command.</summary>
    /// <value>The skip command.</value>
    /// <autogeneratedoc />
    [StringLength(256)]
    public string? SkipCommand { get; set; }
}
