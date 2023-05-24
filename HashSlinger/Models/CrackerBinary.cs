﻿namespace HashSlinger.Api.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>A cracker binary. Typically hashcat.</summary>
/// <autogeneratedoc />
public record CrackerBinary
{
    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    /// <autogeneratedoc />
    public int Id { get; set; }

    /// <summary>Gets or sets the cracker binary type identifier.</summary>
    /// <value>The cracker binary type identifier.</value>
    /// <autogeneratedoc />
    public int CrackerBinaryTypeId { get; set; }

    /// <summary>Gets or sets the version.</summary>
    /// <value>The version.</value>
    /// <autogeneratedoc />
    [StringLength(20)]
    public string Version { get; set; } = null!;

    /// <summary>Gets or sets the download URL.</summary>
    /// <value>The download URL.</value>
    /// <autogeneratedoc />
    [StringLength(150)]
    public string DownloadUrl { get; set; } = null!;

    /// <summary>Gets or sets the name of the binary.</summary>
    /// <value>The name of the binary.</value>
    /// <autogeneratedoc />
    [StringLength(50)]
    public string BinaryName { get; set; } = null!;

    /// <summary>Gets or sets the type of the cracker binary.</summary>
    /// <value>The type of the cracker binary.</value>
    /// <autogeneratedoc />
    public virtual CrackerBinaryType CrackerBinaryType { get; set; } = null!;

    /// <summary>Gets or sets the health checks.</summary>
    /// <value>The health checks.</value>
    /// <autogeneratedoc />
    public virtual ICollection<HealthCheck> HealthChecks { get; set; } = new List<HealthCheck>();

    /// <summary>Gets or sets the tasks.</summary>
    /// <value>The tasks.</value>
    /// <autogeneratedoc />
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
