﻿namespace HashSlinger.Shared.Models;

/// <summary>Represents a binary hash. Typically used for WIFI hashes.</summary>
/// <autogeneratedoc />
public record BinaryHash : HashBase
{
    /// <summary>Gets or sets the essid.</summary>
    /// <value>The essid.</value>
    /// <autogeneratedoc />
    // ReSharper disable once IdentifierTypo
    public string Essid { get; set; } = null!;

    /// <summary>Gets or sets the hash.</summary>
    /// <value>The hash.</value>
    /// <autogeneratedoc />
    public byte[] HashBytes { get; set; } = null!;
}
