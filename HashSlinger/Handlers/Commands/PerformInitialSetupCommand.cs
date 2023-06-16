namespace HashSlinger.Api.Handlers.Commands;

using Data;
using MediatR;
using Models;
using Task = System.Threading.Tasks.Task;

/// <summary>Represents a command to perform the initial setup of the application.</summary>
public record PerformInitialSetupCommand : IRequest;

/// <summary>Handles the initial setup of the application.</summary>

// ReSharper disable once UnusedMember.Global
// ReSharper disable once UnusedType.Global
public class PerformInitialSetupHandler : IRequestHandler<PerformInitialSetupCommand>
{
    private readonly HashSlingerContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="PerformInitialSetupHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    public PerformInitialSetupHandler(HashSlingerContext dbContext) => _dbContext = dbContext;

    /// <summary>Handles a request</summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    public Task Handle(PerformInitialSetupCommand request, CancellationToken cancellationToken)
    {
        // Clean up the database.
        _dbContext.Agents.RemoveRange(_dbContext.Agents);
        _dbContext.Users.RemoveRange(_dbContext.Users);
        _dbContext.RegistrationVouchers.RemoveRange(_dbContext.RegistrationVouchers);
        _dbContext.AccessGroups.RemoveRange(_dbContext.AccessGroups);
        _dbContext.DownloadableBinaries.RemoveRange(_dbContext.DownloadableBinaries);
        _dbContext.LogEntries.RemoveRange(_dbContext.LogEntries);
        _dbContext.SaveChanges();

        var defaultGroup = new AccessGroup { Name = "Default" };
        _dbContext.AccessGroups.Add(defaultGroup);
        var admin = new User
        {
            Email = "admin@localhost", UserName = "admin",
            RegisteredSince = DateTime.UtcNow
        };
        admin.SetPasswordHash("admin");
        defaultGroup.Users.Add(admin);
        _dbContext.Users.Add(admin);
        _dbContext.RegistrationVouchers.Add(new RegistrationVoucher
            { Voucher = "abcd", AccessGroup = defaultGroup });

        _dbContext.AgentBinaries.Add(new AgentBinary
        {
            DownloadUrl = "https://archive.hashtopolis.org/agent/python/stable/0.7.1.zip",
            Executable = "https://archive.hashtopolis.org/agent/python/stable/0.7.1.zip",
            Name = "hashtopolis.zip",
            OperatingSystems = new List<string> { "Windows", "Linux", "OS X" },
            Version = "0.7.1",
            Type = "python",
            UpdateAvailable = string.Empty,
            UpdateTrack = "stable"
        });

        _dbContext.DownloadableBinaries.Add(new DownloadableBinary
        {
            Executable = "7zr.exe",

            // This is not idea, but it is for testing. You should host your own binaries.
            DownloadUrl = "https://github.com/hashtopolis/server/raw/master/src/static/7zr.exe",
            Name = "7zr",
            OperatingSystems = new List<string> { "windows" },
            Version = "1.0.0"
        });

        _dbContext.CrackerBinaries.Add(new CrackerBinary
        {
            Executable = "hashcat",
            DownloadUrl = "https://hashcat.net/files/hashcat-6.2.6.7z",
            Name = "hashcat",
            OperatingSystems = new List<string> { "Windows", "Linux", "OS X" },
            Version = "6.2.6",
            CrackerBinaryType = new CrackerBinaryType
            {
                IsChunkingAvailable = true,
                TypeName = "hashcat"
            }
        });

        _dbContext.SaveChanges();

        return Task.CompletedTask;
    }
}
