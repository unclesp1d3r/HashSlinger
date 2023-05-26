namespace HashSlinger.Api.DAL;

using Models;

/// <summary>Represents the main data access layer.</summary>
public interface IHashSlingerRepository : IDisposable
{
    /// <summary>Gets the user.</summary>
    /// <param name="username"></param>
    /// <returns></returns>
    User GetUser(string username);
}
