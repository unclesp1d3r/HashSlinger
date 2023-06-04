namespace HashSlinger.Api.DAL;

using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using SemanticVersioning;
using Serilog;

/// <summary>Represents the data storage provider for business objects</summary>
public class Repository
{
    /// <summary>The database context</summary>
    internal HashSlingerContext DbContext = null!;

    /// <summary>Gets the registration voucher asynchronously.</summary>
    /// <param name="voucher">The voucher.</param>
    /// <returns>The RegistrationVoucher, or null.</returns>
    public Task<RegistrationVoucher?> GetRegistrationVoucherAsync(string voucher)
    {
        Log.Debug("Getting voucher {voucher}", voucher);
        return DbContext.RegistrationVouchers.FirstOrDefaultAsync(v => v.Voucher == voucher);
    }

    /// <summary>Creates the agent asynchronously.</summary>
    /// <param name="newAgent">The new agent.</param>
    /// <returns>The number of agents created. Should be 1.</returns>
    public async Task<int> CreateAgentAsync(Agent newAgent)
    {
        Log.Information("Creating agent {@newAgent}", newAgent);
        await DbContext.Agents.AddAsync(newAgent).ConfigureAwait(true);
        int result = await DbContext.SaveChangesAsync().ConfigureAwait(true);
        return result;
    }

    /// <summary>Deletes the registration voucher asynchronously.</summary>
    /// <param name="voucher">The voucher.</param>
    /// <returns>The number of records deleted. Should be 1.<br /></returns>
    public Task<int> DeleteRegistrationVoucherAsync(RegistrationVoucher voucher)
    {
        Log.Information("Deleting voucher {@voucher}", voucher);
        DbContext.RegistrationVouchers.Remove(voucher);
        return DbContext.SaveChangesAsync();
    }

    /// <summary>Gets the agent asynchronously.</summary>
    /// <param name="agentId">The agent identifier.</param>
    public Task<Agent?> GetAgentByIdAsync(int agentId)
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

    /// <summary>Gets the agent binary asynchronously.</summary>
    /// <param name="type">The type.</param>
    /// <param name="currentVersion">The current version used by the client.</param>
    /// <returns>The most recent agent binary for the requested type.</returns>
    /// <remarks>
    ///   <para>This is a stupid way to do this, so I'll need to clean this up. </para>
    ///   <para>I plan to use the semantic versioning because I want to be able to restrict the version on a per-agent basis.</para>
    /// </remarks>
    public async Task<AgentBinary?> GetAgentBinaryAsync(string type, string currentVersion)
    {
        Log.Debug("Getting client binary for type {type}", type);
        var satisfyingRange = new Range($">={currentVersion}");
        List<AgentBinary> getBinaries = await DbContext.AgentBinaries.Where(b => b.Type == type)
            .ToListAsync()
            .ConfigureAwait(true);

        IEnumerable<Version> validVersions = getBinaries.Select(b => new Version(b.Version))
            .Where(v => satisfyingRange.IsSatisfied(v));
        Version? latestVersion = satisfyingRange.MaxSatisfying(validVersions);

        AgentBinary? clientBinary = getBinaries.FirstOrDefault(b => b.Version == latestVersion?.ToString());
        Log.Debug("The latest version for {type} is {version}", type, clientBinary!.Version);
        return clientBinary;
    }

    /// <summary>Gets the default user.</summary>
    /// <returns>
    ///   <br />
    /// </returns>
    public Task<User?> GetDefaultUser()
    {
        Log.Debug("Getting default user");
        return DbContext.Users.FirstOrDefaultAsync();
    }
}
