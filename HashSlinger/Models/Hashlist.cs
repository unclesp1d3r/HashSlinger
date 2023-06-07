﻿namespace HashSlinger.Api.Models;

using System.ComponentModel.DataAnnotations;

/// <summary>A list of hashes.</summary>
/// <autogeneratedoc />
public record Hashlist
{
    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    /// <autogeneratedoc />
    public int Id { get; set; }

    /// <summary>Gets or sets the name of the hashlist.</summary>
    /// <value>The name of the hashlist.</value>
    /// <autogeneratedoc />
    [StringLength(100)]
    public string Name { get; set; } = null!;

    /// <summary>Gets or sets the format.</summary>
    /// <value>The format.</value>
    /// <autogeneratedoc />
    public int Format { get; set; }

    /// <summary>Gets or sets the hash type identifier.</summary>
    /// <value>The hash type identifier.</value>
    /// <autogeneratedoc />
    public int HashTypeId { get; set; }

    /// <summary>Gets or sets the hash count.</summary>
    /// <value>The hash count.</value>
    /// <autogeneratedoc />
    public int HashCount { get; set; }

    /// <summary>Gets or sets the salt separator.</summary>
    /// <value>The salt separator.</value>
    /// <autogeneratedoc />
    [StringLength(10)]
    public string? SaltSeparator { get; set; }

    /// <summary>Gets or sets the cracked.</summary>
    /// <value>The cracked.</value>
    /// <autogeneratedoc />
    public int Cracked { get; set; }

    /// <summary>Gets or sets a value indicating whether this instance is secret.</summary>
    /// <value><c>true</c> if this instance is secret; otherwise, <c>false</c>.</value>
    /// <autogeneratedoc />
    public bool IsSecret { get; set; }

    /// <summary>Gets or sets a value indicating whether [hexadecimal salt].</summary>
    /// <value><c>true</c> if [hexadecimal salt]; otherwise, <c>false</c>.</value>
    /// <autogeneratedoc />
    public bool HexSalt { get; set; }

    /// <summary>Gets or sets a value indicating whether this instance is salted.</summary>
    /// <value><c>true</c> if this instance is salted; otherwise, <c>false</c>.</value>
    /// <autogeneratedoc />
    public bool IsSalted { get; set; }

    /// <summary>Gets or sets the access group identifier.</summary>
    /// <value>The access group identifier.</value>
    /// <autogeneratedoc />
    public int AccessGroupId { get; set; }

    /// <summary>Gets or sets the notes.</summary>
    /// <value>The notes.</value>
    /// <autogeneratedoc />
    public string Notes { get; set; } = null!;

    /// <summary>Gets or sets the brain identifier.</summary>
    /// <value>The brain identifier.</value>
    /// <autogeneratedoc />
    public int BrainId { get; set; }

    /// <summary>Gets or sets the brain features.</summary>
    /// <value>The brain features.</value>
    /// <autogeneratedoc />
    public short BrainFeatures { get; set; }

    /// <summary>Gets or sets a value indicating whether this instance is archived.</summary>
    /// <value><c>true</c> if this instance is archived; otherwise, <c>false</c>.</value>
    /// <autogeneratedoc />
    public bool IsArchived { get; set; }

    /// <summary>Gets or sets the access group.</summary>
    /// <value>The access group.</value>
    /// <autogeneratedoc />
    public virtual AccessGroup AccessGroup { get; set; } = null!;

    /// <summary>Gets or sets the hash binaries.</summary>
    /// <value>The hash binaries.</value>
    /// <autogeneratedoc />
    public virtual ICollection<HashBinary> HashBinaries { get; set; } = new List<HashBinary>();

    /// <summary>Gets or sets the type of the hash.</summary>
    /// <value>The type of the hash.</value>
    /// <autogeneratedoc />
    public virtual HashType HashType { get; set; } = null!;

    /// <summary>Gets or sets the hashes.</summary>
    /// <value>The hashes.</value>
    /// <autogeneratedoc />
    public virtual ICollection<Hash> Hashes { get; set; } = new List<Hash>();

    /// <summary>Gets or sets the task wrappers.</summary>
    /// <value>The task wrappers.</value>
    /// <autogeneratedoc />
    public virtual ICollection<TaskWrapper> TaskWrappers { get; set; } = new List<TaskWrapper>();

    /// <summary>Gets or sets the zaps.</summary>
    /// <value>The zaps.</value>
    /// <autogeneratedoc />
    public virtual ICollection<Zap> Zaps { get; set; } = new List<Zap>();
}
