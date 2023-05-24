namespace HashSlinger.Api.Utilities;

using System.Security.Cryptography;
using System.Text;

/// <summary>
///  General utility methods related to authentication.
/// </summary>
public static class Authentication
{
    private const int KeySize = 64;
    private const int Iterations = 350000;
    private static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA512;

    /// <summary>Verifies a password against a hash and salt.</summary>
    /// <param name="password">The password.</param>
    /// <param name="hash">The hash.</param>
    /// <param name="salt">The salt.</param>
    /// <returns>
    ///   True if the password matches the hash and salt; else false.
    /// </returns>
    public static bool VerifyPassword(string password, string hash, byte[] salt)
    {
        byte[] hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations,
            HashAlgorithm, KeySize);
        return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
    }

    /// <summary>Hashes the password and returns a salt and hash.</summary>
    /// <param name="password">The plaintext password.</param>
    /// <returns>A tuple of hash and the salt.</returns>
    public static (string, byte[]) HashPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(KeySize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            Iterations,
            HashAlgorithm,
            KeySize);
        return (Convert.ToHexString(hash), salt);
    }
}
