namespace HashSlinger.Api.DAL;
/// <summary>Represents the main data access layer.</summary>
public interface IHashSlingerRepository : IDisposable
{
    /// <summary>Gets the registration voucher.</summary>
    /// <param name="voucher">The voucher string.</param>
    /// <returns>A <see cref="RegistrationVoucher" /> or null, if the voucher is not found.</returns>
    Task<RegistrationVoucher> GetRegistrationVoucherAsync(string voucher);

    User GetUser(string username);
    HashSlingerContext Context { get; set; }
}
