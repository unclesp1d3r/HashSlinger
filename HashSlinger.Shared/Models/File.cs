﻿namespace HashSlinger.Shared.Models;

using System.ComponentModel.DataAnnotations;

/// <summary>Represents a file.</summary>
/// <autogeneratedoc />
public record File
{
    /// <summary>Gets or sets the access group.</summary>
    /// <value>The access group.</value>
    /// <autogeneratedoc />
    public virtual AccessGroup AccessGroup { get; set; } = null!;

    /// <summary>Gets or sets the file downloads.</summary>
    /// <value>The file downloads.</value>
    /// <autogeneratedoc />
    public virtual ICollection<FileDownload> FileDownloads { get; set; } = new List<FileDownload>();

    /// <summary>Gets or sets the file pretasks.</summary>
    /// <value>The file pretasks.</value>
    /// <autogeneratedoc />
    public virtual ICollection<PreconfiguredTask> PreconfiguredTasks { get; set; } = new List<PreconfiguredTask>();

    /// <summary>Gets or sets the file tasks.</summary>
    /// <value>The file tasks.</value>
    /// <autogeneratedoc />
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    /// <summary>Gets or sets the access group identifier.</summary>
    /// <value>The access group identifier.</value>
    /// <autogeneratedoc />
    public int AccessGroupId { get; set; }


    /// <summary>Gets or sets the file unique identifier.</summary>
    /// <value>The file unique identifier.</value>
    public Guid? FileGuid { get; set; }

    /// <summary>Gets or sets the name of the file.</summary>
    /// <value>The name of the file.</value>
    [StringLength(100)]
    public string FileName { get; set; } = null!;

    /// <summary>Gets or sets the type of the file.</summary>
    /// <value>The type of the file.</value>
    /// <autogeneratedoc />
    public int FileType { get; set; }

    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    /// <autogeneratedoc />
    public int Id { get; set; }

    /// <summary>Gets or sets a value indicating whether this instance is secret.</summary>
    /// <value><c>true</c> if this instance is secret; otherwise, <c>false</c>.</value>
    /// <autogeneratedoc />
    public bool IsSecret { get; set; }

    /// <summary>Gets or sets the line count.</summary>
    /// <value>The line count.</value>
    /// <autogeneratedoc />
    public long? LineCount { get; set; }

    /// <summary>Gets or sets the size.</summary>
    /// <value>The size, in bytes.</value>
    /// <autogeneratedoc />
    public long Size { get; set; }
}