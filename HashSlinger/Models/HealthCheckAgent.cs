﻿namespace HashSlingerApi.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>Represents the results of a health check. Serves as a mapping table between the agent, the healthcheck, and the results.</summary>
/// <autogeneratedoc />
public class HealthCheckAgent
{
    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    /// <autogeneratedoc />
    public int Id { get; set; }

    /// <summary>Gets or sets the health check identifier.</summary>
    /// <value>The health check identifier.</value>
    /// <autogeneratedoc />
    public int HealthCheckId { get; set; }

    /// <summary>Gets or sets the agent identifier.</summary>
    /// <value>The agent identifier.</value>
    /// <autogeneratedoc />
    public int AgentId { get; set; }

    /// <summary>Gets or sets the status.</summary>
    /// <value>The status.</value>
    /// <autogeneratedoc />
    public int Status { get; set; }

    /// <summary>Gets or sets the cracked.</summary>
    /// <value>The cracked.</value>
    /// <autogeneratedoc />
    public int Cracked { get; set; }

    /// <summary>Gets or sets the number gpus.</summary>
    /// <value>The number gpus.</value>
    /// <autogeneratedoc />
    public int NumGpus { get; set; }

    /// <summary>Gets or sets the start.</summary>
    /// <value>The start.</value>
    /// <autogeneratedoc />
    public DateTime Start { get; set; }

    /// <summary>Gets or sets the end.</summary>
    /// <value>The end.</value>
    /// <autogeneratedoc />
    public DateTime End { get; set; }

    /// <summary>Gets or sets the errors.</summary>
    /// <value>The errors.</value>
    /// <autogeneratedoc />
    public string Errors { get; set; } = null!;


    /// <summary>Gets or sets the agent.</summary>
    /// <value>The agent.</value>
    /// <autogeneratedoc />
    public virtual Agent Agent { get; set; } = null!;


    /// <summary>Gets or sets the health check.</summary>
    /// <value>The health check.</value>
    /// <autogeneratedoc />
    public virtual HealthCheck HealthCheck { get; set; } = null!;
}
