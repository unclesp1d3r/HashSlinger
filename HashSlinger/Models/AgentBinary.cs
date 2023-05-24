﻿namespace HashSlinger.Api.Models;

using System.ComponentModel.DataAnnotations;

/// <summary>A copy of the hashtopolis agent software.</summary>
/// <autogeneratedoc />
public class AgentBinary
{
    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    /// <autogeneratedoc />
    public int Id { get; set; }

    /// <summary>Gets or sets the type.</summary>
    /// <value>The type.</value>
    /// <autogeneratedoc />
    [StringLength(20)]
    public string Type { get; set; } = null!;

    /// <summary>Gets or sets the version.</summary>
    /// <value>The version.</value>
    /// <autogeneratedoc />
    [StringLength(20)]
    public string Version { get; set; } = null!;

    /// <summary>Gets or sets the operating systems.</summary>
    /// <value>The operating systems.</value>
    /// <autogeneratedoc />
    [StringLength(50)]
    public string OperatingSystems { get; set; } = null!;

    /// <summary>Gets or sets the filename.</summary>
    /// <value>The filename.</value>
    /// <autogeneratedoc />
    [StringLength(50)]
    public string Filename { get; set; } = null!;

    /// <summary>Gets or sets the update track.</summary>
    /// <value>The update track.</value>
    /// <autogeneratedoc />
    [StringLength(20)]
    public string UpdateTrack { get; set; } = null!;

    /// <summary>Gets or sets the update available.</summary>
    /// <value>The update available.</value>
    /// <autogeneratedoc />
    [StringLength(20)]
    public string UpdateAvailable { get; set; } = null!;
}
