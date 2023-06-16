﻿namespace HashSlinger.Api.Models;

using System.ComponentModel.DataAnnotations;

/// <summary>A preconfigured cracking task.</summary>
/// <autogeneratedoc />
public record PreconfiguredTask
{
    /// <summary>Gets or sets the type of the cracker binary.</summary>
    /// <value>The type of the cracker binary.</value>
    /// <autogeneratedoc />
    public virtual CrackerBinaryType CrackerBinaryType { get; set; } = null!;

    /// <summary>Gets or sets the files.</summary>
    /// <value>The files.</value>
    /// <autogeneratedoc />
    public virtual ICollection<File> Files { get; set; } = new List<File>();

    /// <summary>Gets or sets the supertask pretasks.</summary>
    /// <value>The supertask pretasks.</value>
    /// <autogeneratedoc />
    public virtual ICollection<SupertaskPretask> SupertaskPretasks { get; set; }
        = new List<SupertaskPretask>();

    /// <summary>Gets or sets the attack command.</summary>
    /// <value>The attack command.</value>
    /// <autogeneratedoc />
    [StringLength(256)]
    public string AttackCommand { get; set; } = null!;

    /// <summary>Gets or sets the chunk time.</summary>
    /// <value>The chunk time.</value>
    /// <autogeneratedoc />
    public int ChunkTime { get; set; }

    /// <summary>Gets or sets the color.</summary>
    /// <value>The color.</value>
    /// <autogeneratedoc />
    [StringLength(20)]
    public string? Color { get; set; }

    /// <summary>Gets or sets the cracker binary type identifier.</summary>
    /// <value>The cracker binary type identifier.</value>
    /// <autogeneratedoc />
    public int CrackerBinaryTypeId { get; set; }

    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    /// <autogeneratedoc />
    public int Id { get; set; }

    /// <summary>Gets or sets a value indicating whether this instance is cpu task.</summary>
    /// <value><c>true</c> if this instance is cpu task; otherwise, <c>false</c>.</value>
    /// <autogeneratedoc />
    public bool IsCpuTask { get; set; }

    /// <summary>Gets or sets a value indicating whether this instance is mask import.</summary>
    /// <value><c>true</c> if this instance is mask import; otherwise, <c>false</c>.</value>
    /// <autogeneratedoc />
    public bool IsMaskImport { get; set; }

    /// <summary>Gets or sets a value indicating whether this instance is small.</summary>
    /// <value><c>true</c> if this instance is small; otherwise, <c>false</c>.</value>
    /// <autogeneratedoc />
    public bool IsSmall { get; set; }

    /// <summary>Gets or sets the maximum agents.</summary>
    /// <value>The maximum agents.</value>
    /// <autogeneratedoc />
    public int MaxAgents { get; set; }

    /// <summary>Gets or sets the name of the task.</summary>
    /// <value>The name of the task.</value>
    /// <autogeneratedoc />
    [StringLength(100)]
    public string Name { get; set; } = null!;

    /// <summary>Gets or sets the priority.</summary>
    /// <value>The priority.</value>
    /// <autogeneratedoc />
    public int Priority { get; set; }

    /// <summary>Gets or sets the status timer.</summary>
    /// <value>The status timer.</value>
    /// <autogeneratedoc />
    public int StatusTimer { get; set; }

    /// <summary>Gets or sets a value indicating whether to use the speed benchmark.</summary>
    /// <value><c>true</c> if use speed benchmark; otherwise, <c>false</c>.</value>
    /// <autogeneratedoc />
    public bool UseNewBench { get; set; }
}
