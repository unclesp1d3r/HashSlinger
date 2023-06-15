﻿namespace HashSlinger.Api.Models;

using System.ComponentModel.DataAnnotations;

/// <summary>Represents a cracking task.</summary>
/// <autogeneratedoc />
public record Task
{
    /// <summary>Gets or sets the agent errors.</summary>
    /// <value>The agent errors.</value>
    /// <autogeneratedoc />
    public virtual ICollection<AgentError> AgentErrors { get; set; } = new List<AgentError>();

    /// <summary>Gets or sets the assignments.</summary>
    /// <value>The assignments.</value>
    /// <autogeneratedoc />
    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    /// <summary>Gets or sets the chunks.</summary>
    /// <value>The chunks.</value>
    /// <autogeneratedoc />
    public virtual ICollection<Chunk> Chunks { get; set; } = new List<Chunk>();

    /// <summary>Gets or sets the cracker binary.</summary>
    /// <value>The cracker binary.</value>
    /// <autogeneratedoc />
    public virtual CrackerBinary? CrackerBinary { get; set; }

    /// <summary>Gets or sets the type of the cracker binary.</summary>
    /// <value>The type of the cracker binary.</value>
    /// <autogeneratedoc />
    public virtual CrackerBinaryType? CrackerBinaryType { get; set; }

    /// <summary>Gets or sets the file tasks.</summary>
    /// <value>The file tasks.</value>
    /// <autogeneratedoc />
    public virtual ICollection<FileTask> FileTasks { get; set; } = new List<FileTask>();

    /// <summary>Gets or sets the speeds.</summary>
    /// <value>The speeds.</value>
    /// <autogeneratedoc />
    public virtual ICollection<Speed> Speeds { get; set; } = new List<Speed>();

    /// <summary>Gets or sets the task debug outputs.</summary>
    /// <value>The task debug outputs.</value>
    /// <autogeneratedoc />
    public virtual ICollection<TaskDebugOutput> TaskDebugOutputs { get; set; } = new List<TaskDebugOutput>();

    /// <summary>Gets or sets the task wrapper.</summary>
    /// <value>The task wrapper.</value>
    /// <autogeneratedoc />
    public virtual TaskWrapper TaskWrapper { get; set; } = null!;

    /// <summary>Gets or sets the attack command.</summary>
    /// <value>The attack command.</value>
    /// <autogeneratedoc />
    [StringLength(256)]
    public string AttackCommand { get; set; } = null!;

    /// <summary>Gets or sets the size of the chunk.</summary>
    /// <value>The size of the chunk.</value>
    /// <autogeneratedoc />
    public ulong ChunkSize { get; set; }

    /// <summary>Gets or sets the chunk time.</summary>
    /// <value>The chunk time, in seconds.</value>
    /// <autogeneratedoc />
    public int ChunkTime { get; set; }

    /// <summary>Gets or sets the color.</summary>
    /// <value>The color.</value>
    /// <remarks>Not sure this still makes sense</remarks>
    /// <autogeneratedoc />
    [StringLength(20)]
    public string? Color { get; set; }

    /// <summary>Gets or sets the cracker binary identifier.</summary>
    /// <value>The cracker binary identifier.</value>
    /// <autogeneratedoc />
    public int? CrackerBinaryId { get; set; }

    /// <summary>Gets or sets the cracker binary type identifier.</summary>
    /// <value>The cracker binary type identifier.</value>
    /// <autogeneratedoc />
    public int? CrackerBinaryTypeId { get; set; }

    /// <summary>Gets or sets a value indicating whether to force a pipe task.</summary>
    /// <value><c>true</c> if [force pipe]; otherwise, <c>false</c>.</value>
    /// <autogeneratedoc />
    public bool ForcePipe { get; set; }

    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    /// <autogeneratedoc />
    public int Id { get; set; }

    /// <summary>Gets or sets a value indicating whether this instance is archived.</summary>
    /// <value><c>true</c> if this instance is archived; otherwise, <c>false</c>.</value>
    /// <autogeneratedoc />
    public bool IsArchived { get; set; }

    /// <summary>Gets or sets a value indicating whether this instance is cpu task.</summary>
    /// <value><c>true</c> if this instance is cpu task; otherwise, <c>false</c>.</value>
    /// <autogeneratedoc />
    public bool IsCpuTask { get; set; }

    /// <summary>Gets or sets a value indicating whether this instance is small.</summary>
    /// <value><c>true</c> if this instance is small; otherwise, <c>false</c>.</value>
    /// <autogeneratedoc />
    public bool IsSmall { get; set; }

    /// <summary>Gets or sets the keyspace.</summary>
    /// <value>The keyspace.</value>
    /// <autogeneratedoc />
    public ulong Keyspace { get; set; }

    /// <summary>Gets or sets the keyspace progress.</summary>
    /// <value>The keyspace progress.</value>
    /// <autogeneratedoc />
    public ulong KeyspaceProgress { get; set; }

    /// <summary>Gets or sets the maximum agents.</summary>
    /// <value>The maximum agents.</value>
    /// <autogeneratedoc />
    public int MaxAgents { get; set; }

    /// <summary>Gets or sets the name.</summary>
    /// <value>The name.</value>
    [StringLength(256)]
    public string Name { get; set; } = null!;

    /// <summary>Gets or sets the notes.</summary>
    /// <value>The notes.</value>
    /// <autogeneratedoc />
    public string Notes { get; set; } = null!;

    /// <summary>Gets or sets the preprocessor command.</summary>
    /// <value>The preprocessor command.</value>
    /// <autogeneratedoc />
    [StringLength(256)]
    public string PreprocessorCommand { get; set; } = null!;

    /// <summary>Gets or sets the priority.</summary>
    /// <value>The priority.</value>
    /// <autogeneratedoc />
    public int Priority { get; set; }

    /// <summary>Gets or sets the skip keyspace.</summary>
    /// <value>The skip keyspace.</value>
    /// <autogeneratedoc />
    public ulong SkipKeyspace { get; set; }

    /// <summary>Gets or sets the number of static chunks.</summary>
    /// <value>The static chunk count.</value>
    /// <autogeneratedoc />
    public int StaticChunks { get; set; }

    /// <summary>Gets or sets the status timer.</summary>
    /// <value>The status timer.</value>
    /// <autogeneratedoc />
    public int StatusTimer { get; set; }

    /// <summary>Gets or sets the task wrapper identifier.</summary>
    /// <value>The task wrapper identifier.</value>
    /// <autogeneratedoc />
    public int TaskWrapperId { get; set; }

    /// <summary>Gets or sets a value indicating whether [use new benchmark].</summary>
    /// <value><c>true</c> if [use new benchmark]; otherwise, <c>false</c>.</value>
    public bool UseNewBenchmark { get; set; }

    /// <summary>Gets or sets a value indicating whether [use preprocessor].</summary>
    /// <value><c>true</c> if [use preprocessor]; otherwise, <c>false</c>.</value>
    /// <autogeneratedoc />
    public bool UsePreprocessor { get; set; }
}
