namespace HashSlinger.Api.Models;

using System.ComponentModel.DataAnnotations;

/// <summary>A file deletion event.</summary>
public record FileDelete
{
    /// <summary>Gets or sets the name of the file.</summary>
    /// <value>The name of the file.</value>
    [StringLength(256)]
    public string FileName { get; set; } = null!;

    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    public int Id { get; set; }

    /// <summary>Gets or sets the time of the deletion.</summary>
    /// <value>The time.</value>
    public DateTime Time { get; set; }
}
