namespace HashSlinger.Api.DAL;

using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enums;
using SemanticVersioning;
using Serilog;

/// <summary>Represents the data storage provider for business objects</summary>
public class Repository
{
    private const string Issuer = "Hashtopolis API";

    /// <summary>The database context</summary>
    internal HashSlingerContext DbContext = null!;

    /// <summary>Gets the registration voucher asynchronously.</summary>
    /// <param name="voucher">The voucher.</param>
    /// <returns>The RegistrationVoucher, or null.</returns>
    public Task<RegistrationVoucher?> GetRegistrationVoucherAsync(string voucher)
    {
        Log.Debug("Getting voucher {voucher}", voucher);
        return DbContext.RegistrationVouchers.SingleOrDefaultAsync(v => v.Voucher == voucher);
    }

    /// <summary>Creates the agent asynchronously.</summary>
    /// <param name="newAgent">The new agent.</param>
    /// <returns>The number of agents created. Should be 1.</returns>
    public async Task<int> CreateAgentAsync(Agent newAgent)
    {
        await WriteLogEventAsync(LogEntry.Information($"Creating agent {newAgent}", Issuer))
            .ConfigureAwait(true);
        await DbContext.Agents.AddAsync(newAgent).ConfigureAwait(true);
        return await DbContext.SaveChangesAsync().ConfigureAwait(true);
    }

    /// <summary>Deletes the registration voucher asynchronously.</summary>
    /// <param name="voucher">The voucher.</param>
    /// <returns>The number of records deleted. Should be 1.<br /></returns>
    public async Task<int> DeleteRegistrationVoucherAsync(RegistrationVoucher voucher)
    {
        await WriteLogEventAsync(LogEntry.Information($"Deleting voucher {voucher}", Issuer))
            .ConfigureAwait(true);
        DbContext.RegistrationVouchers.Remove(voucher);
        return await DbContext.SaveChangesAsync().ConfigureAwait(true);
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
        await WriteLogEventAsync(LogEntry.Information($"Updating agent {agent}", Issuer))
            .ConfigureAwait(true);
        DbContext.Agents.Update(agent);
        return await DbContext.SaveChangesAsync().ConfigureAwait(true);
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
    ///     <para>This is a stupid way to do this, so I'll need to clean this up. </para>
    ///     <para>
    ///         I plan to use the semantic versioning because I want to be able to restrict the version on a
    ///         per-agent basis.
    ///     </para>
    /// </remarks>
    public async Task<AgentBinary?> GetAgentBinaryAsync(string type, string currentVersion)
    {
        Log.Debug("Getting client binary for type {type}", type);
        var satisfyingRange = new Range($">={currentVersion}");
        List<AgentBinary> getBinaries = await DbContext.AgentBinaries.Where(b => b.Type == type)
            .ToListAsync()
            .ConfigureAwait(true);

        if (getBinaries.Count == 0)
        {
            await WriteLogEventAsync(LogEntry.Warning($"No binaries found for type {type}", Issuer))
                .ConfigureAwait(true);
            return null;
        }

        IEnumerable<Version> validVersions = getBinaries.Select(b => new Version(b.Version))
            .Where(v => satisfyingRange.IsSatisfied(v));
        Version? latestVersion = satisfyingRange.MaxSatisfying(validVersions);

        AgentBinary? clientBinary = getBinaries.FirstOrDefault(b => b.Version == latestVersion?.ToString());
        Log.Debug("The latest version for {type} is {version}", type, clientBinary!.Version);
        return clientBinary;
    }

    /// <summary>Gets the default user.</summary>
    /// <returns>
    ///     <br />
    /// </returns>
    public Task<User?> GetDefaultUserAsync()
    {
        Log.Debug("Getting default user");
        return DbContext.Users.FirstOrDefaultAsync();
    }

    /// <summary>Writes the log event.</summary>
    /// <param name="logEntry">The log entry.</param>
    /// <returns>The number of records logged. It should be 1.<br /></returns>
    /// <exception cref="System.ArgumentOutOfRangeException">Happens on an invalid LogEntryLevel</exception>
    public async Task<int> WriteLogEventAsync(LogEntry logEntry)
    {
        switch (logEntry.Level)
        {
            case LogEntryLevels.Trace:
                Log.Verbose(logEntry.Message);
                break;
            case LogEntryLevels.Debug:
                Log.Debug(logEntry.Message);
                break;
            case LogEntryLevels.Information:
                Log.Information(logEntry.Message);
                break;
            case LogEntryLevels.Warning:
                Log.Warning(logEntry.Message);
                break;
            case LogEntryLevels.Error:
                Log.Error(logEntry.Message);
                break;
            case LogEntryLevels.Fatal:
                Log.Fatal(logEntry.Message);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(logEntry));
        }

        await DbContext.LogEntries.AddAsync(logEntry).ConfigureAwait(true);
        return await DbContext.SaveChangesAsync().ConfigureAwait(true);
    }

    public async Task<DownloadableBinary?> GetBinaryAsync(string name)
    {
        DownloadableBinary? result = await DbContext.DownloadableBinaries.Where(b => b.Name == name)
            .OrderByDescending(b => b.Version)
            .LastOrDefaultAsync()
            .ConfigureAwait(true);
        return result;
    }
}
