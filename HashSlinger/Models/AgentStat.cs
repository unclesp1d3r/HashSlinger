﻿namespace HashSlingerApi.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>Statistics about an agent.</summary>
/// <autogeneratedoc />
public class AgentStat
{
    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    /// <autogeneratedoc />
    public int Id { get; set; }

    /// <summary>Gets or sets the agent identifier.</summary>
    /// <value>The agent identifier.</value>
    /// <autogeneratedoc />
    public int AgentId { get; set; }

    /// <summary>Gets or sets the type of the stat.</summary>
    /// <value>The type of the stat.</value>
    /// <autogeneratedoc />
    public int StatType { get; set; }

    /// <summary>Gets or sets the time.</summary>
    /// <value>The time.</value>
    /// <autogeneratedoc />
    public DateTime Time { get; set; }

    /// <summary>Gets or sets the value.</summary>
    /// <value>The value.</value>
    /// <autogeneratedoc />
    [StringLength(128)]
    public string Value { get; set; } = null!;

    /// <summary>Gets or sets the agent.</summary>
    /// <value>The agent.</value>
    /// <autogeneratedoc />
    [ForeignKey("AgentId")]
    [InverseProperty("AgentStats")]
    public virtual Agent Agent { get; set; } = null!;
}
