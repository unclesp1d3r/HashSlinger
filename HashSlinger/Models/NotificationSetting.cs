﻿namespace HashSlinger.Api.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>Represents a notification destination.</summary>
/// <autogeneratedoc />
public class NotificationSetting
{
    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    /// <autogeneratedoc />
    public int Id { get; set; }

    /// <summary>Gets or sets the action.</summary>
    /// <value>The action.</value>
    /// <autogeneratedoc />
    [StringLength(50)]
    public string Action { get; set; } = null!;

    /// <summary>Gets or sets the object identifier.</summary>
    /// <value>The object identifier.</value>
    /// <autogeneratedoc />
    public int? ObjectId { get; set; }

    /// <summary>Gets or sets the notification.</summary>
    /// <value>The notification.</value>
    /// <autogeneratedoc />
    [StringLength(50)]
    public string Notification { get; set; } = null!;

    /// <summary>Gets or sets the user identifier.</summary>
    /// <value>The user identifier.</value>
    /// <autogeneratedoc />
    public int UserId { get; set; }

    /// <summary>Gets or sets the receiver.</summary>
    /// <value>The receiver.</value>
    /// <autogeneratedoc />
    [StringLength(256)]
    public string Receiver { get; set; } = null!;

    /// <summary>Gets or sets a value indicating whether this instance is active.</summary>
    /// <value>
    ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
    /// <autogeneratedoc />
    public bool IsActive { get; set; }

    /// <summary>Gets or sets the user.</summary>
    /// <value>The user.</value>
    /// <autogeneratedoc />
    [InverseProperty("NotificationSettings")]
    public virtual User User { get; set; } = null!;
}
