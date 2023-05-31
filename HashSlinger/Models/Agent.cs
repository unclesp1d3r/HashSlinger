﻿namespace HashSlinger.Api.Models;

using System.ComponentModel.DataAnnotations;
using Enums;

/// <summary>A system running the client software and processing cracking jobs.</summary>
/// <autogeneratedoc />
public record Agent
{
    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    /// <autogeneratedoc />
    public int Id { get; set; }

    /// <summary>Gets or sets the name.</summary>
    /// <value>The name.</value>
    /// <autogeneratedoc />
    [StringLength(100)]
    public string Name { get; set; } = null!;

    /// <summary>Gets or sets the uid.</summary>
    /// <value>The uid.</value>
    /// <autogeneratedoc />
    [StringLength(100)]
    public string Uid { get; set; } = string.Empty;

    /// <summary>Gets or sets the operating system.</summary>
    /// <value>The operating system.</value>
    public AgentOperatingSystems OperatingSystem { get; set; } = AgentOperatingSystems.Unknown;

    /// <summary>Gets or sets the devices.</summary>
    /// <value>The devices.</value>
    /// <autogeneratedoc />
    public ICollection<string> Devices { get; set; } = new List<string>();

    /// <summary>Gets or sets the command parameters.</summary>
    /// <value>The command pars.</value>
    /// <autogeneratedoc />
    [StringLength(256)]
    public string CommandParameters { get; set; } = string.Empty;

    /// <summary>Gets or sets a value indicating whether [ignore errors].</summary>
    /// <value><c>true</c> if [ignore errors]; otherwise, <c>false</c>.</value>
    /// <autogeneratedoc />
    public bool IgnoreErrors { get; set; } = false;

    /// <summary>Gets or sets a value indicating whether this instance is active.</summary>
    /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
    /// <autogeneratedoc />
    public bool IsActive { get; set; } = false;

    /// <summary>Gets or sets a value indicating whether this instance is trusted.</summary>
    /// <value><c>true</c> if this instance is trusted; otherwise, <c>false</c>.</value>
    /// <autogeneratedoc />
    public bool IsTrusted { get; set; } = false;

    /// <summary>Gets or sets the token.</summary>
    /// <value>The token.</value>
    /// <autogeneratedoc />
    [StringLength(30)]
    public string Token { get; set; } = null!;

    /// <summary>Gets or sets the last act.</summary>
    /// <value>The last act.</value>
    /// <autogeneratedoc />
    public AgentActions LastAction { get; set; } = AgentActions.Unknown;

    /// <summary>Gets or sets the last time  observed.</summary>
    /// <value>The last time observed.</value>
    /// <autogeneratedoc />
    public DateTime LastTime { get; set; } = DateTime.UtcNow;

    /// <summary>Gets or sets the last ip.</summary>
    /// <value>The last ip.</value>
    /// <autogeneratedoc />
    [StringLength(50)]
    public string LastIp { get; set; } = string.Empty;

    /// <summary>Gets or sets the user identifier.</summary>
    /// <value>The user identifier.</value>
    /// <autogeneratedoc />
    public int? UserId { get; set; }

    /// <summary>Gets or sets a value indicating whether [cpu only].</summary>
    /// <value><c>true</c> if [cpu only]; otherwise, <c>false</c>.</value>
    /// <autogeneratedoc />
    public bool CpuOnly { get; set; } = false;

    /// <summary>Gets or sets the client signature.</summary>
    /// <value>The client signature.</value>
    /// <autogeneratedoc />
    [StringLength(50)]
    public string ClientSignature { get; set; } = string.Empty;

    /// <summary>Gets or sets the access group agents.</summary>
    /// <value>The access group agents.</value>
    /// <autogeneratedoc />
    public virtual ICollection<AccessGroupAgent> AccessGroupAgents { get; set; }
        = new List<AccessGroupAgent>();

    /// <summary>Gets or sets the agent errors.</summary>
    /// <value>The agent errors.</value>
    /// <autogeneratedoc />
    public virtual ICollection<AgentError> AgentErrors { get; set; } = new List<AgentError>();

    /// <summary>Gets or sets the agent stats.</summary>
    /// <value>The agent stats.</value>
    /// <autogeneratedoc />
    public virtual ICollection<AgentStat> AgentStats { get; set; } = new List<AgentStat>();

    /// <summary>Gets or sets the agent zaps.</summary>
    /// <value>The agent zaps.</value>
    /// <autogeneratedoc />
    public virtual ICollection<AgentZap> AgentZaps { get; set; } = new List<AgentZap>();

    /// <summary>Gets or sets the assignments.</summary>
    /// <value>The assignments.</value>
    /// <autogeneratedoc />
    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    /// <summary>Gets or sets the chunks.</summary>
    /// <value>The chunks.</value>
    /// <autogeneratedoc />
    public virtual ICollection<Chunk> Chunks { get; set; } = new List<Chunk>();

    /// <summary>Gets or sets the health check agents.</summary>
    /// <value>The health check agents.</value>
    /// <autogeneratedoc />
    public virtual ICollection<HealthCheckAgent> HealthCheckAgents { get; set; }
        = new List<HealthCheckAgent>();

    /// <summary>Gets or sets the speeds.</summary>
    /// <value>The speeds.</value>
    /// <autogeneratedoc />
    public virtual ICollection<Speed> Speeds { get; set; } = new List<Speed>();

    /// <summary>Gets or sets the user.</summary>
    /// <value>The user.</value>
    /// <autogeneratedoc />
    public virtual User? User { get; set; }

    /// <summary>Gets or sets the zaps.</summary>
    /// <value>The zaps.</value>
    /// <autogeneratedoc />

    public virtual ICollection<Zap> Zaps { get; set; } = new List<Zap>();
}
