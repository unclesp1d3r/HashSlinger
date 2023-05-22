namespace HashSlinger.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    public int Id { get; set; }

    [StringLength(100)] public string Username { get; set; } = null!;

    [StringLength(150)] public string Email { get; set; } = null!;

    [StringLength(256)] public string PasswordHash { get; set; } = null!;

    [StringLength(256)] public string PasswordSalt { get; set; } = null!;

    public bool IsValid { get; set; }

    public DateTime LastLoginDate { get; set; }

    public DateTime RegisteredSince { get; set; }

    public int SessionLifetime { get; set; }
}