﻿namespace HashSlinger.Api.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>A super task, comprised of a number of preconfigured tasks running in sequence.</summary>
/// <autogeneratedoc />
[Table("Supertask")]
public class Supertask
{
    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    /// <autogeneratedoc />
    public int Id { get; set; }

    /// <summary>Gets or sets the name of the supertask.</summary>
    /// <value>The name of the supertask.</value>
    /// <autogeneratedoc />
    [StringLength(50)]
    public string SupertaskName { get; set; } = null!;

    /// <summary>Gets or sets the supertask pretasks.</summary>
    /// <value>The supertask pretasks.</value>
    /// <autogeneratedoc />
    [InverseProperty("Supertask")]
    public virtual ICollection<SupertaskPretask> SupertaskPretasks { get; set; } = new List<SupertaskPretask>();
}