﻿namespace HashSlinger.Api.Models;

using System.ComponentModel.DataAnnotations.Schema;

/// <summary>A mapping between a preconfigured task and an associated file.</summary>
/// <autogeneratedoc />
public record FilePretask
{
    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    /// <autogeneratedoc />
    public int Id { get; set; }

    /// <summary>Gets or sets the file identifier.</summary>
    /// <value>The file identifier.</value>
    /// <autogeneratedoc />
    public int FileId { get; set; }

    /// <summary>Gets or sets the pretask identifier.</summary>
    /// <value>The pretask identifier.</value>
    /// <autogeneratedoc />
    public int PretaskId { get; set; }

    /// <summary>Gets or sets the file.</summary>
    /// <value>The file.</value>
    /// <autogeneratedoc />
    public virtual File File { get; set; } = null!;

    /// <summary>Gets or sets the pretask.</summary>
    /// <value>The pretask.</value>
    /// <autogeneratedoc />
    public virtual Pretask Pretask { get; set; } = null!;
}
