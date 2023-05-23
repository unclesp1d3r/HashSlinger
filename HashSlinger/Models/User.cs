namespace HashSlingerApi.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>This class represents a user in the system. A user is an individual who can register, login, and perform various activities within the application.</summary>
public class User
{
    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    public int Id { get; set; }

    /// <summary>Gets or sets the username.</summary>
    /// <value>The username.</value>
    [StringLength(100)]
    public string Username { get; set; } = null!;

    /// <summary>Gets or sets the email.</summary>
    /// <value>The email.</value>
    [StringLength(150)]
    public string Email { get; set; } = null!;

    /// <summary>Gets or sets the password hash.</summary>
    /// <value>The password hash.</value>
    [StringLength(256)]
    public string PasswordHash { get; set; } = null!;

    /// <summary>Gets or sets the password salt.</summary>
    /// <value>The password salt.</value>
    [StringLength(256)]
    public string PasswordSalt { get; set; } = null!;

    /// <summary>Returns true if ... is valid.</summary>
    /// <value>
    ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
    public bool IsValid { get; set; }


    /// <summary>Gets or sets the last login date.</summary>
    /// <value>The last login date.</value>
    public DateTime LastLoginDate { get; set; }

    /// <summary>Gets or sets the registered since.</summary>
    /// <value>The registered since.</value>
    public DateTime RegisteredSince { get; set; }


    /// <summary>Gets or sets the access group users.</summary>
    /// <value>The access group users.</value>
    [InverseProperty("User")]
    public virtual ICollection<AccessGroupUser> AccessGroupUsers { get; set; } = new List<AccessGroupUser>();

    /// <summary>Gets or sets the agents.</summary>
    /// <value>The agents.</value>
    [InverseProperty("User")]
    public virtual ICollection<Agent> Agents { get; set; } = new List<Agent>();

    /// <summary>Gets or sets the API keys.</summary>
    /// <value>The API keys.</value>
    [InverseProperty("User")]
    public virtual ICollection<ApiKey> ApiKeys { get; set; } = new List<ApiKey>();

    /// <summary>Gets or sets the notification settings.</summary>
    /// <value>The notification settings.</value>
    [InverseProperty("User")]
    public virtual ICollection<NotificationSetting> NotificationSettings { get; set; } =
        new List<NotificationSetting>();


    /// <summary>Gets or sets the sessions.</summary>
    /// <value>The sessions.</value>
    [InverseProperty("User")]
    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
