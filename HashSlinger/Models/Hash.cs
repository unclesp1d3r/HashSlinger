﻿namespace HashSlinger.Api.Models;

using System.ComponentModel.DataAnnotations;

/// <summary>A hash.</summary>
/// <autogeneratedoc />
public record Hash
{
    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    /// <autogeneratedoc />
    public int Id { get; set; }

    /// <summary>Gets or sets the hashlist identifier.</summary>
    /// <value>The hashlist identifier.</value>
    /// <autogeneratedoc />
    public int HashlistId { get; set; }

    /// <summary>Gets or sets the hash value.</summary>
    /// <value>The hash value.</value>
    /// <autogeneratedoc />
    public string HashValue { get; set; } = null!;

    /// <summary>Gets or sets the salt.</summary>
    /// <value>The salt.</value>
    /// <autogeneratedoc />
    [StringLength(256)]
    public string? Salt { get; set; }

    /// <summary>Gets or sets the plaintext.</summary>
    /// <value>The plaintext.</value>
    /// <autogeneratedoc />
    [StringLength(256)]
    public string? Plaintext { get; set; }

    /// <summary>Gets or sets the time cracked.</summary>
    /// <value>The time cracked.</value>
    /// <autogeneratedoc />
    public DateTime? TimeCracked { get; set; }

    /// <summary>Gets or sets the chunk identifier.</summary>
    /// <value>The chunk identifier.</value>
    /// <autogeneratedoc />
    public int? ChunkId { get; set; }

    /// <summary>Gets or sets a value indicating whether this instance is cracked.</summary>
    /// <value><c>true</c> if this instance is cracked; otherwise, <c>false</c>.</value>
    /// <autogeneratedoc />
    public bool IsCracked { get; set; }

    /// <summary>Gets or sets the crack position.</summary>
    /// <value>The crack position.</value>
    /// <autogeneratedoc />
    public ulong CrackPos { get; set; }

    /// <summary>Gets or sets the chunk.</summary>
    /// <value>The chunk.</value>
    /// <autogeneratedoc />
    public virtual Chunk? Chunk { get; set; }

    /// <summary>Gets or sets the hashlist.</summary>
    /// <value>The hashlist.</value>
    /// <autogeneratedoc />
    public virtual Hashlist Hashlist { get; set; } = null!;
}
