namespace HashSlinger.Api.DAL;

using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;

public class HashSlingerRepository : IHashSlingerRepository
{
    /// <inheritdoc />
    public Task<RegistrationVoucher> GetRegistrationVoucherAsync(string voucher)
    {
        return Context.RegistrationVouchers.FirstOrDefaultAsync(v => v.Voucher == voucher)!;
    }

    /// <inheritdoc />
    public User GetUser(string username)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public HashSlingerContext Context { get; set; }

    /// <inheritdoc />
    public void Dispose() { }
}
