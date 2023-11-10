﻿namespace HashSlinger.Shared.Models;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Mapster;
using Utilities;

/// <summary>
///     This class represents a user in the system. A user is an individual who can register, login, and perform
///     various activities within the application.
/// </summary>
public record User
{
    /// <summary>Gets or sets the access group users.</summary>
    /// <value>The access group users.</value>
    public virtual ICollection<AccessGroup> AccessGroups { get; set; } = new List<AccessGroup>();

    /// <summary>Gets or sets the agents.</summary>
    /// <value>The agents.</value>
    [JsonIgnore] [AdaptIgnore]
    public virtual ICollection<Agent> Agents { get; set; } = new List<Agent>();

    /// <summary>Gets or sets the API keys.</summary>
    /// <value>The API keys.</value>
    public virtual ICollection<ApiKey> ApiKeys { get; set; } = new List<ApiKey>();

    /// <summary>Gets or sets the notification settings.</summary>
    /// <value>The notification settings.</value>
    public virtual ICollection<NotificationSetting> NotificationSettings { get; set; } = new List<NotificationSetting>();


    /// <summary>Gets or sets the sessions.</summary>
    /// <value>The sessions.</value>
    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

    /// <summary>Gets or sets the email.</summary>
    /// <value>The email.</value>
    [StringLength(150)]
    public string Email { get; set; } = null!;

    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    public int Id { get; set; }


    /// <summary>Returns true if ... is valid.</summary>
    /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
    public bool IsValid { get; set; }


    /// <summary>Gets or sets the last login date.</summary>
    /// <value>The last login date.</value>
    public DateTime LastLoginDate { get; set; }

    /// <summary>Gets or sets the password hash.</summary>
    /// <value>The password hash.</value>
    [StringLength(256)] [JsonIgnore] [AdaptIgnore]
    public string PasswordHash { get; set; } = null!;

    /// <summary>Gets or sets the password salt.</summary>
    /// <value>The password salt.</value>
    [JsonIgnore] [AdaptIgnore]
    public byte[] PasswordSalt { get; set; } = null!;

    /// <summary>Gets or sets the registered since.</summary>
    /// <value>The registered since.</value>
    public DateTime RegisteredSince { get; set; }

    /// <summary>Gets or sets the name of the user.</summary>
    /// <value>The name of the user.</value>
    [StringLength(100)]
    public string UserName { get; set; } = null!;

    /// <summary>Sets the password hash and salt.</summary>
    /// <param name="password">The plaintext password.</param>
    public void SetPasswordHash(string password)
    {
        (PasswordHash, PasswordSalt) = Authentication.HashPassword(password);
    }

    /// <summary>Validates a plaintext password against the hashed password.</summary>
    /// <param name="password">The plaintext password.</param>
    /// <returns>True, if the password matches the stored user password; else false.</returns>
    /// <autogeneratedoc />
    public bool ValidatePassword(string password)
    {
        return Authentication.VerifyPassword(password, PasswordHash, PasswordSalt);
    }
}
