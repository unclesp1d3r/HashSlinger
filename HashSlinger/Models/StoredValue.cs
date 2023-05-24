﻿namespace HashSlinger.Api.Models;

using System.ComponentModel.DataAnnotations;

/// <summary>An arbitrary key-value storage.
/// Need to figure out what this is used for in the new system.</summary>
/// <autogeneratedoc />
public class StoredValue
{
    /// <summary>Gets or sets the stored value identifier.</summary>
    /// <value>The stored value identifier.</value>
    /// <autogeneratedoc />
    [Key]
    [StringLength(50)]
    public string StoredValueId { get; set; } = null!;

    /// <summary>Gets or sets the value.</summary>
    /// <value>The value.</value>
    /// <autogeneratedoc />
    [StringLength(256)]
    public string Value { get; set; } = null!;
}
