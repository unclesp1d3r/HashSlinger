namespace HashSlinger.Api.DAL;

using Models;

/// <summary>Represents the main data access layer.</summary>
public interface IHashSlingerRepository : IDisposable
{
    User GetUser(string username);
}
