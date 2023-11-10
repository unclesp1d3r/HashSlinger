namespace HashSlinger.Api.Handlers.Commands;

using Data;
using Mapster;
using MediatR;
using Shared.Models;
using Shared.Models.Enums;
using Utilities;
using Task = Task;

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
        _dbContext.DownloadableBinaries.RemoveRange(_dbContext.DownloadableBinaries);
        _dbContext.AgentBinaries.RemoveRange(_dbContext.AgentBinaries);
        _dbContext.Users.RemoveRange(_dbContext.Users);
        _dbContext.RegistrationVouchers.RemoveRange(_dbContext.RegistrationVouchers);
        _dbContext.AccessGroups.RemoveRange(_dbContext.AccessGroups);
        _dbContext.HealthChecks.RemoveRange(_dbContext.HealthChecks);
        _dbContext.LogEntries.RemoveRange(_dbContext.LogEntries);
        _dbContext.CrackerBinaries.RemoveRange(_dbContext.CrackerBinaries);
        _dbContext.Hashlists.RemoveRange(_dbContext.Hashlists);
        _dbContext.Files.RemoveRange(_dbContext.Files);
        _dbContext.SaveChanges();

        // Seed the database.

        _dbContext.AgentBinaries.Add(new AgentBinary
        {
            Type = "python",
            DownloadUrl = "https://archive.hashtopolis.org/agent/python/stable/0.7.1.zip",
            Executable = "https://archive.hashtopolis.org/agent/python/stable/0.7.1.zip",
            Name = "hashtopolis.zip",
            OperatingSystems = new List<string>
            {
                AgentOperatingSystems.Windows.Adapt<string>(),
                AgentOperatingSystems.Linux.Adapt<string>(),
                AgentOperatingSystems.MacOS.Adapt<string>()
            },
            Version = "0.7.1",
            UpdateAvailable = string.Empty,
            UpdateTrack = "stable"
        });

        _dbContext.DownloadableBinaries.Add(new DownloadableBinary
        {
            Executable = "7zr.exe",
            // This is not a good idea, but it is for testing. You should host your own binaries.
            DownloadUrl = "https://github.com/hashtopolis/server/raw/master/src/static/7zr",
            Name = "7zr",
            OperatingSystems = new List<string> { AgentOperatingSystems.Windows.Adapt<string>() },
            Version = "1.0.0"
        });


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
        _dbContext.RegistrationVouchers.Add(new RegistrationVoucher { Voucher = "abcd", AccessGroup = defaultGroup });
        if (!_dbContext.HashTypes.Any())
            _dbContext.HashTypes.AddRange(SeedTool.GetHashTypeSeeds());
        _dbContext.SaveChanges();

        var hashcat = new CrackerBinary
        {
            Executable = "hashcat",
            DownloadUrl = "https://hashcat.net/files/hashcat-6.2.6.7z",
            Name = "hashcat",
            OperatingSystems = new List<string>
            {
                AgentOperatingSystems.Windows.Adapt<string>(),
                AgentOperatingSystems.Linux.Adapt<string>(),
                AgentOperatingSystems.MacOS.Adapt<string>()
            },
            Version = "6.2.6",
            CrackerBinaryType = _dbContext.CrackerBinaryTypes.Single(x => x.TypeName == "hashcat")
        };
        _dbContext.CrackerBinaries.Add(hashcat);

        var hashlist = new Hashlist
        {
            AccessGroup = defaultGroup,
            Hashes = new List<Hash>
            {
                new()
                {
                    HashValue = "e2fc714c4727ee9395f324cd2e7f331f",
                    IsCracked = false
                }
            },
            HashType = _dbContext.HashTypes.Single(x => x.HashcatId == 0),
            BrainFeatures = 0,
            BrainId = 0,
            Cracked = 0,
            Format = HashListFormats.TextFile,
            HashCount = 1,
            HexSalt = false,
            IsArchived = false,
            IsSalted = false,
            IsSecret = false,
            Name = "Test Hashlist",
            Notes = "Just a test.",
            SaltSeparator = null
        };
        _dbContext.Hashlists.Add(hashlist);

        var passwordList = new File
        {
            AccessGroup = defaultGroup,
            FileName = "500-worst-passwords.txt",
            IsSecret = false,
            FileType = FileType.WordList,
            LineCount = 500,
            Size = 3491
        };
        _dbContext.Files.Add(passwordList);

        var newTask = new Shared.Models.Task
        {
            CrackerBinary = hashcat,
            CrackerBinaryType = _dbContext.CrackerBinaryTypes.Single(x => x.TypeName == "hashcat"),
            TaskWrapper = new TaskWrapper
            {
                AccessGroup = defaultGroup,
                Hashlist = hashlist,
                IsArchived = false,
                Name = "Test Task",
                Priority = 0
            },
            AttackCommand = "-a 0 #HL# 500-worst-passwords.txt",
            ChunkSize = 600,
            EnforcePipe = false,
            IsArchived = false,
            IsCpuTask = false,
            IsSmall = false,
            Files = new List<File> { passwordList },
            MaxAgents = 0,
            Name = "Test Task",
            Notes = "It's perfect. No notes.",
            Priority = 0,
            SkipKeyspace = 0,
            StaticChunks = 0,
            StatusTimer = 5,
            UseNewBenchmark = true,
            UsePreprocessor = false
        };
        _dbContext.Tasks.Add(newTask);


        _dbContext.SaveChanges();

        return Task.CompletedTask;
    }
}
