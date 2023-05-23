﻿namespace HashSlingerApi.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>A wrapper object that maps a task, hashlist, and priority.</summary>
/// <autogeneratedoc />
public class TaskWrapper
{
    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    /// <autogeneratedoc />
    public int Id { get; set; }

    /// <summary>Gets or sets the priority.</summary>
    /// <value>The priority.</value>
    /// <autogeneratedoc />
    public int Priority { get; set; }

    /// <summary>Gets or sets the type of the task.</summary>
    /// <value>The type of the task.</value>
    /// <autogeneratedoc />
    public int TaskType { get; set; }

    /// <summary>Gets or sets the hashlist identifier.</summary>
    /// <value>The hashlist identifier.</value>
    /// <autogeneratedoc />
    public int HashlistId { get; set; }

    /// <summary>Gets or sets the access group identifier.</summary>
    /// <value>The access group identifier.</value>
    /// <autogeneratedoc />
    public int? AccessGroupId { get; set; }

    /// <summary>Gets or sets the name of the task wrapper.</summary>
    /// <value>The name of the task wrapper.</value>
    /// <autogeneratedoc />
    [StringLength(100)]
    public string TaskWrapperName { get; set; } = null!;


    /// <summary>Gets or sets a value indicating whether this instance is archived.</summary>
    /// <value>
    ///   <c>true</c> if this instance is archived; otherwise, <c>false</c>.</value>
    /// <autogeneratedoc />
    public bool IsArchived { get; set; }

    /// <summary>Gets or sets the number of hashes cracked.</summary>
    /// <value>The cracked count.</value>
    /// <autogeneratedoc />
    public int Cracked { get; set; }

    /// <summary>Gets or sets the access group.</summary>
    /// <value>The access group.</value>
    /// <autogeneratedoc />
    [ForeignKey("AccessGroupId")]
    [InverseProperty("TaskWrappers")]
    public virtual AccessGroup? AccessGroup { get; set; }

    /// <summary>Gets or sets the hashlist.</summary>
    /// <value>The hashlist.</value>
    /// <autogeneratedoc />
    [ForeignKey("HashlistId")]
    [InverseProperty("TaskWrappers")]
    public virtual Hashlist Hashlist { get; set; } = null!;

    /// <summary>Gets or sets the tasks.</summary>
    /// <value>The tasks.</value>
    /// <autogeneratedoc />
    [InverseProperty("TaskWrapper")]
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
