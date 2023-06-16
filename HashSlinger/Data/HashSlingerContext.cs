﻿namespace HashSlinger.Api.Data;

using Microsoft.EntityFrameworkCore;
using Models;

/// <summary>A DbContext instance representing a session with the database.</summary>
/// <autogeneratedoc />
public partial class HashSlingerContext : DbContext
{
    /// <summary>Initializes a new instance of the <see cref="HashSlingerContext" /> class.</summary>
    /// <param name="options">The options.</param>
    /// <autogeneratedoc />
    public HashSlingerContext(DbContextOptions<HashSlingerContext> options) : base(options) { }

    /// <summary>Gets or sets the access groups.</summary>
    /// <value>The access groups.</value>
    public DbSet<AccessGroup> AccessGroups { get; set; } = null!;

    /// <summary>Gets or sets the agent binaries.</summary>
    /// <value>The agent binaries.</value>
    public DbSet<AgentBinary> AgentBinaries { get; set; } = null!;

    /// <summary>Gets or sets the agents.</summary>
    /// <value>The agents.</value>
    public DbSet<Agent> Agents { get; set; } = null!;

    /// <summary>Gets or sets the cracker binaries.</summary>
    /// <value>The cracker binaries.</value>
    public DbSet<CrackerBinary> CrackerBinaries { get; set; } = null!;

    /// <summary>Gets or sets the downloadable binaries.</summary>
    /// <value>The downloadable binaries.</value>
    public DbSet<DownloadableBinary> DownloadableBinaries { get; set; } = null!;

    /// <summary>Gets or sets the files.</summary>
    /// <value>The files.</value>
    public DbSet<File> Files { get; set; } = null!;

    /// <summary>Gets or sets the log entries.</summary>
    /// <value>The log entries.</value>
    public DbSet<LogEntry> LogEntries { get; set; } = null!;

    /// <summary>Gets or sets the registration vouchers.</summary>
    /// <value>The registration vouchers.</value>
    /// <autogeneratedoc />
    public DbSet<RegistrationVoucher> RegistrationVouchers { get; set; } = null!;

    /// <summary>Gets or sets the users.</summary>
    /// <value>The users.</value>
    /// <autogeneratedoc />
    public DbSet<User> Users { get; set; } = null!;

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccessGroup>(entity =>
        {
            entity.HasMany(e => e.RegistrationVouchers)
                .WithOne(e => e.AccessGroup)
                .OnDelete(DeleteBehavior.ClientSetNull);
            entity.HasMany(e => e.Users).WithMany(e => e.AccessGroups);
        });

        modelBuilder.Entity<Agent>(entity =>
        {
            entity.HasMany(e => e.Zaps).WithOne(e => e.Agent).OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(e => e.Stats).WithOne(e => e.Agent).OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(e => e.Chunks).WithOne(e => e.Agent).OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(e => e.AccessGroups).WithMany(e => e.Agents);
            entity.HasMany(e => e.Assignments).WithOne(e => e.Agent).OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(e => e.Errors).WithOne(e => e.Agent).OnDelete(DeleteBehavior.Cascade);
        });


        modelBuilder.Entity<AgentStat>(entity =>
        {
            entity.HasOne(d => d.Agent).WithMany(p => p.Stats).OnDelete(DeleteBehavior.ClientSetNull);
        });


        modelBuilder.Entity<ApiKey>(entity =>
        {
            entity.HasOne(d => d.ApiGroup).WithMany(p => p.ApiKeys).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.ApiKeys).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.HasOne(d => d.Agent).WithMany(p => p.Assignments).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Task).WithMany(p => p.Assignments).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Chunk>(entity =>
        {
            entity.HasOne(d => d.Agent).WithMany(p => p.Chunks);

            entity.HasOne(d => d.Task).WithMany(p => p.Chunks).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CrackerBinary>(entity =>
        {
            entity.HasOne(d => d.CrackerBinaryType)
                .WithMany(p => p.CrackerBinaries)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<File>(entity =>
        {
            entity.HasOne(d => d.AccessGroup).WithMany(p => p.Files).OnDelete(DeleteBehavior.ClientSetNull);
            entity.HasMany(e => e.PreconfiguredTasks).WithMany(e => e.Files);
        });

        modelBuilder.Entity<FileDownload>(entity =>
        {
            entity.HasOne(d => d.File)
                .WithMany(p => p.FileDownloads)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });


        modelBuilder.Entity<FileTask>(entity =>
        {
            entity.HasOne(d => d.File).WithMany(p => p.FileTasks).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Task).WithMany(p => p.FileTasks).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Hash>(entity =>
        {
            entity.HasOne(d => d.Chunk).WithMany(p => p.Hashes);

            entity.HasOne(d => d.Hashlist).WithMany(p => p.Hashes).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<HashBinary>(entity =>
        {
            entity.HasOne(d => d.Chunk).WithMany(p => p.HashBinaries);

            entity.HasOne(d => d.Hashlist)
                .WithMany(p => p.HashBinaries)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Hashlist>(entity =>
        {
            entity.HasOne(d => d.AccessGroup)
                .WithMany(p => p.Hashlists)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.HashType).WithMany(p => p.Hashlists).OnDelete(DeleteBehavior.ClientSetNull);
        });


        modelBuilder.Entity<HealthCheck>(entity =>
        {
            entity.HasOne(d => d.CrackerBinary)
                .WithMany(p => p.HealthChecks)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<HealthCheckAgent>(entity =>
        {
            entity.HasOne(d => d.Agent)
                .WithMany(p => p.HealthCheckAgents)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.HealthCheck)
                .WithMany(p => p.HealthCheckAgents)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<NotificationSetting>(entity =>
        {
            entity.HasOne(d => d.User)
                .WithMany(p => p.NotificationSettings)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PreconfiguredTask>(entity =>
        {
            entity.HasOne(d => d.CrackerBinaryType)
                .WithMany(p => p.Pretasks)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<RegistrationVoucher>(entity =>
            entity.HasOne(r => r.AccessGroup).WithMany(a => a.RegistrationVouchers));


        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.Sessions).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Speed>(entity =>
        {
            entity.HasOne(d => d.Agent).WithMany(p => p.Speeds).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Task).WithMany(p => p.Speeds).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SupertaskPretask>(entity =>
        {
            entity.HasOne(d => d.PreconfiguredTask)
                .WithMany(p => p.SupertaskPretasks)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Supertask)
                .WithMany(p => p.SupertaskPretasks)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasOne(d => d.CrackerBinary).WithMany(p => p.Tasks);

            entity.HasOne(d => d.CrackerBinaryType).WithMany(p => p.Tasks);

            entity.HasOne(d => d.TaskWrapper).WithMany(p => p.Tasks).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TaskDebugOutput>(entity =>
        {
            entity.HasOne(d => d.Task)
                .WithMany(p => p.TaskDebugOutputs)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TaskWrapper>(entity =>
        {
            entity.HasOne(d => d.AccessGroup).WithMany(p => p.TaskWrappers);

            entity.HasOne(d => d.Hashlist)
                .WithMany(p => p.TaskWrappers)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasMany(e => e.Agents).WithOne(e => e.User).OnDelete(DeleteBehavior.ClientSetNull);
            entity.HasMany(e => e.AccessGroups).WithMany(e => e.Users);
            entity.HasMany(e => e.ApiKeys).WithOne(e => e.User).OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(e => e.NotificationSettings).WithOne(e => e.User).OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(e => e.Sessions).WithOne(e => e.User).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Zap>(entity =>
        {
            entity.HasOne(d => d.Agent).WithMany(p => p.Zaps);

            entity.HasOne(d => d.Hashlist).WithMany(p => p.Zaps).OnDelete(DeleteBehavior.ClientSetNull);
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
