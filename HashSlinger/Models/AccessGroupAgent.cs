﻿namespace HashSlinger.Api.Models;

using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
///   <para>A join object for mapping Agents to Access Groups</para>
/// </summary>
/// <autogeneratedoc />
public record AccessGroupAgent
{
    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    /// <autogeneratedoc />
    public int Id { get; set; }

    /// <summary>Gets or sets the access group identifier.</summary>
    /// <value>The access group identifier.</value>
    /// <autogeneratedoc />
    public int AccessGroupId { get; set; }

    /// <summary>Gets or sets the agent identifier.</summary>
    /// <value>The agent identifier.</value>
    /// <autogeneratedoc />
    public int AgentId { get; set; }

    /// <summary>Gets or sets the access group.</summary>
    /// <value>The access group.</value>
    /// <autogeneratedoc />
    public virtual AccessGroup AccessGroup { get; set; } = null!;

    /// <summary>Gets or sets the agent.</summary>
    /// <value>The agent.</value>
    /// <autogeneratedoc />
    public virtual Agent Agent { get; set; } = null!;
}
