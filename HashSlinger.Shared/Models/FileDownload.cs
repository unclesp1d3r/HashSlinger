﻿namespace HashSlinger.Shared.Models;

/// <summary>A file download event.</summary>
/// <autogeneratedoc />
public record FileDownload
{
    /// <summary>Gets or sets the file.</summary>
    /// <value>The file.</value>
    /// <autogeneratedoc />
    public virtual File File { get; set; } = null!;

    /// <summary>Gets or sets the file identifier.</summary>
    /// <value>The file identifier.</value>
    /// <autogeneratedoc />
    public int FileId { get; set; }

    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    /// <autogeneratedoc />
    public int Id { get; set; }

    /// <summary>Gets or sets the status.</summary>
    /// <value>The status.</value>
    /// <autogeneratedoc />
    public int Status { get; set; }

    /// <summary>Gets or sets the time.</summary>
    /// <value>The time.</value>
    /// <autogeneratedoc />
    public DateTime Time { get; set; }
}
