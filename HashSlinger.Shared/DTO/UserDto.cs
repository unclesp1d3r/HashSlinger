namespace HashSlinger.Shared.DTO;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public record UserDto
{
    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    public int Id { get; set; }

    /// <summary>Gets or sets the name of the user.</summary>
    /// <value>The name of the user.</value>
    [StringLength(100)]
    public string UserName { get; set; } = null!;

    /// <summary>Gets or sets the email.</summary>
    /// <value>The email.</value>
    [StringLength(150)]
    public string Email { get; set; } = null!;

    /// <summary>Returns true if ... is valid.</summary>
    /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
    public bool IsValid { get; set; }


    /// <summary>Gets or sets the last login date.</summary>
    /// <value>The last login date.</value>
    public DateTime LastLoginDate { get; set; }

    /// <summary>Gets or sets the registered since.</summary>
    /// <value>The registered since.</value>
    public DateTime RegisteredSince { get; set; }

    /// <summary>Gets or sets the password.</summary>
    /// <value>The password.</value>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Password { get; set; }

    [JsonIgnore] public string? PasswordHash { get; set; }
    [JsonIgnore] public byte[]? PasswordSalt { get; set; }
}
