﻿namespace HashSlinger.Api.Models;

/// <summary>
///     Zaps are recovered hashes, cracked by another process or the web UI, that should be removed from the
///     hashlist by the client.
/// </summary>
/// <remarks>TODO: It's a stupid name. We should reconsider</remarks>
/// <autogeneratedoc />
public record Zap
{
    /// <summary>Gets or sets the agent.</summary>
    /// <value>The agent.</value>
    /// <autogeneratedoc />
    public virtual Agent? Agent { get; set; }


    /// <summary>Gets or sets the hashlist.</summary>
    /// <value>The hashlist.</value>
    /// <autogeneratedoc />
    public virtual Hashlist Hashlist { get; set; } = null!;

    /// <summary>Gets or sets the agent identifier.</summary>
    /// <value>The agent identifier.</value>
    /// <autogeneratedoc />
    public int? AgentId { get; set; }

    /// <summary>Gets or sets the hash.</summary>
    /// <value>The hash.</value>
    /// <autogeneratedoc />
    public string Hash { get; set; } = null!;

    /// <summary>Gets or sets the hashlist identifier.</summary>
    /// <value>The hashlist identifier.</value>
    /// <autogeneratedoc />
    public int HashlistId { get; set; }

    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    /// <autogeneratedoc />
    public int Id { get; set; }

    /// <summary>Gets or sets the solve time.</summary>
    /// <value>The solve time.</value>
    /// <autogeneratedoc />
    public long SolveTime { get; set; }
}
