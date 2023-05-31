namespace HashSlinger.Api.DAL;

using Data;
using Microsoft.EntityFrameworkCore;
using Models;

/// <summary>Represents the data storage provider for business objects</summary>
public static class Repository
{
    /// <summary>Gets the registration voucher asynchronous.</summary>
    /// <param name="db">The database.</param>
    /// <param name="voucher">The voucher.</param>
    /// <returns>The RegistrationVoucher, or null.</returns>
    public static Task<RegistrationVoucher?> GetRegistrationVoucherAsync(
        HashSlingerContext db,
        string voucher
    )
    {
        return db.RegistrationVouchers.FirstOrDefaultAsync(v => v.Voucher == voucher);
    }

    /// <summary>Creates the agent asynchronous.</summary>
    /// <param name="db">The database.</param>
    /// <param name="newAgent">The new agent.</param>
    /// <returns>The number of agents created. Should be 1.</returns>
    public static async Task<int> CreateAgentAsync(HashSlingerContext db, Agent newAgent)
    {
        await db.Agents.AddAsync(newAgent).ConfigureAwait(true);
        int result = await db.SaveChangesAsync().ConfigureAwait(true);
        return result;
    }

    /// <summary>Deletes the registration voucher asynchronous.</summary>
    /// <param name="db">The database.</param>
    /// <param name="voucher">The voucher.</param>
    /// <returns>The number of records deleted. Should be 1.<br /></returns>
    public static Task<int> DeleteRegistrationVoucherAsync(HashSlingerContext db, RegistrationVoucher voucher)
    {
        db.RegistrationVouchers.Remove(voucher);
        return db.SaveChangesAsync();
    }

    /// <summary>Gets the agent asynchronous.</summary>
    /// <param name="db">The database.</param>
    /// <param name="agentId">The agent identifier.</param>
    public static Task<Agent?> GetAgentAsync(HashSlingerContext db, int agentId)
    {
        return db.Agents.FirstOrDefaultAsync(a => a.Id == agentId);
    }

    /// <summary>Updates the agent.</summary>
    /// <param name="db">The database.</param>
    /// <param name="agent">The agent.</param>
    /// <returns>The number of records updated. Should be 1.</returns>
    public static async Task<int> UpdateAgentAsync(HashSlingerContext db, Agent agent)
    {
        db.Agents.Update(agent);
        int result = await db.SaveChangesAsync().ConfigureAwait(true);
        return result;
    }
}
