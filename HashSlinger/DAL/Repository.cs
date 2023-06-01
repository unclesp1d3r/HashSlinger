namespace HashSlinger.Api.DAL;

using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Serilog;

/// <summary>Represents the data storage provider for business objects</summary>
public class Repository
{
    /// <summary>The database context</summary>
    internal HashSlingerContext DbContext;

    /// <summary>Gets the registration voucher asynchronous.</summary>
    /// <param name="voucher">The voucher.</param>
    /// <returns>The RegistrationVoucher, or null.</returns>
    public Task<RegistrationVoucher?> GetRegistrationVoucherAsync(string voucher)
    {
        Log.Debug("Getting voucher {voucher}", voucher);
        return DbContext.RegistrationVouchers.FirstOrDefaultAsync(v => v.Voucher == voucher);
    }

    /// <summary>Creates the agent asynchronous.</summary>
    /// <param name="newAgent">The new agent.</param>
    /// <returns>The number of agents created. Should be 1.</returns>
    public async Task<int> CreateAgentAsync(Agent newAgent)
    {
        Log.Information("Creating agent {@newAgent}", newAgent);
        await DbContext.Agents.AddAsync(newAgent).ConfigureAwait(true);
        int result = await DbContext.SaveChangesAsync().ConfigureAwait(true);
        return result;
    }

    /// <summary>Deletes the registration voucher asynchronous.</summary>
    /// <param name="voucher">The voucher.</param>
    /// <returns>The number of records deleted. Should be 1.<br /></returns>
    public Task<int> DeleteRegistrationVoucherAsync(RegistrationVoucher voucher)
    {
        Log.Information("Deleting voucher {@voucher}", voucher);
        DbContext.RegistrationVouchers.Remove(voucher);
        return DbContext.SaveChangesAsync();
    }

    /// <summary>Gets the agent asynchronous.</summary>
    /// <param name="db">The database.</param>
    /// <param name="agentId">The agent identifier.</param>
    public Task<Agent?> GetAgentAsync(int agentId)
    {
        Log.Debug("Getting agent {agentId}", agentId);
        return DbContext.Agents.FirstOrDefaultAsync(a => a.Id == agentId);
    }

    /// <summary>Updates the agent.</summary>
    /// <param name="agent">The agent.</param>
    /// <returns>The number of records updated. Should be 1.</returns>
    public async Task<int> UpdateAgentAsync(Agent agent)
    {
        Log.Information("Updating agent {@agent}", agent);
        DbContext.Agents.Update(agent);
        int result = await DbContext.SaveChangesAsync().ConfigureAwait(true);
        return result;
    }

    /// <summary>Gets the agent by token asynchronous.</summary>
    /// <param name="token">The token.</param>
    /// <returns>The agent associated with the token, or null.<br /></returns>
    public Task<Agent?> GetAgentByTokenAsync(string token)
    {
        Log.Debug("Getting agent by token {token}", token);
        return DbContext.Agents.FirstOrDefaultAsync(a => a.Token == token);
    }
}
