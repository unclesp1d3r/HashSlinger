﻿namespace HashSlinger.Shared.Models;

using System.ComponentModel.DataAnnotations;

/// <summary>A mapping table for cracker binaries to their types.</summary>
/// <remarks>Not sure this makes sense much longer.</remarks>
/// <autogeneratedoc />
public record CrackerBinaryType
{
    /// <summary>Gets or sets the cracker binaries.</summary>
    /// <value>The cracker binaries.</value>
    /// <autogeneratedoc />
    public virtual ICollection<CrackerBinary> CrackerBinaries { get; set; } = new List<CrackerBinary>();

    /// <summary>Gets or sets the pretasks.</summary>
    /// <value>The pretasks.</value>
    /// <autogeneratedoc />
    public virtual ICollection<PreconfiguredTask> Pretasks { get; set; } = new List<PreconfiguredTask>();

    /// <summary>Gets or sets the tasks.</summary>
    /// <value>The tasks.</value>
    /// <autogeneratedoc />
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    /// <autogeneratedoc />
    public int Id { get; set; }

    /// <summary>Gets or sets a value indicating whether this instance is chunking available.</summary>
    /// <value><c>true</c> if this instance is chunking available; otherwise, <c>false</c>.</value>
    /// <autogeneratedoc />
    public bool IsChunkingAvailable { get; set; }

    /// <summary>Gets or sets the name of the type.</summary>
    /// <value>The name of the type.</value>
    /// <autogeneratedoc />
    [StringLength(30)]
    public string TypeName { get; set; } = null!;
}
