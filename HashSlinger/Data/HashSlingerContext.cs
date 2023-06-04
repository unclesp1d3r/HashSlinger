﻿namespace HashSlinger.Api.Data;

using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;

/// <summary>A DbContext instance representing a session with the database.</summary>
/// <autogeneratedoc />
public partial class HashSlingerContext : DbContext
{
    /// <summary>Initializes a new instance of the <see cref="HashSlingerContext" /> class.</summary>
    /// <param name="options">The options.</param>
    /// <autogeneratedoc />
    public HashSlingerContext(DbContextOptions<HashSlingerContext> options) : base(options) { }

    /// <summary>Gets or sets the users.</summary>
    /// <value>The users.</value>
    /// <autogeneratedoc />
    public DbSet<User> Users { get; set; } = null!;

    /// <summary>Gets or sets the access group.</summary>
    /// <value>The access group.</value>
    /// <autogeneratedoc />
    public DbSet<AccessGroup> AccessGroups { get; set; } = null!;

    /// <summary>Gets or sets the registration vouchers.</summary>
    /// <value>The registration vouchers.</value>
    /// <autogeneratedoc />
    public DbSet<RegistrationVoucher> RegistrationVouchers { get; set; } = null!;

    /// <summary>Gets or sets the agents.</summary>
    /// <value>The agents.</value>
    public DbSet<Agent> Agents { get; set; } = null!;

    /// <summary>Gets or sets the agent binaries.</summary>
    /// <value>The agent binaries.</value>
    public DbSet<AgentBinary> AgentBinaries { get; set; } = null!;

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agent>(entity =>
        {
            entity.Property(e => e.Devices)
                .HasConversion(v => JsonSerializer.Serialize(v, JsonSerializerOptions.Default),
                    v => JsonSerializer.Deserialize<List<string>>(v, JsonSerializerOptions.Default)!,
                    new ValueComparer<ICollection<string>>((c1, c2) => c1!.SequenceEqual(c2!),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => c.ToList()));
        });

        modelBuilder.Entity<AccessGroupAgent>(entity =>
        {
            entity.HasOne(d => d.AccessGroup)
                .WithMany(p => p.AccessGroupAgents)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Agent)
                .WithMany(p => p.AccessGroupAgents)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AccessGroupUser>(entity =>
        {
            entity.HasOne(d => d.AccessGroup)
                .WithMany(p => p.AccessGroupUsers)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User)
                .WithMany(p => p.AccessGroupUsers)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AgentError>(entity =>
        {
            entity.HasOne(d => d.Agent)
                .WithMany(p => p.AgentErrors)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AgentStat>(entity =>
        {
            entity.HasOne(d => d.Agent)
                .WithMany(p => p.AgentStats)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AgentZap>(entity =>
        {
            entity.HasOne(d => d.Agent).WithMany(p => p.AgentZaps).OnDelete(DeleteBehavior.ClientSetNull);
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
            entity.HasOne(d => d.AccessGroup)
                .WithMany(p => p.Files)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<FileDownload>(entity =>
        {
            entity.HasOne(d => d.File)
                .WithMany(p => p.FileDownloads)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<FilePretask>(entity =>
        {
            entity.HasOne(d => d.File).WithMany(p => p.FilePretasks).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Pretask)
                .WithMany(p => p.FilePretasks)
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

        modelBuilder.Entity<HashlistHashlist>(entity =>
        {
            entity.HasOne(d => d.Hashlist)
                .WithMany(p => p.HashlistHashlistHashlists)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ParentHashlist)
                .WithMany(p => p.HashlistHashlistParentHashlists)
                .OnDelete(DeleteBehavior.ClientSetNull);
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

        modelBuilder.Entity<Pretask>(entity =>
        {
            entity.HasOne(d => d.CrackerBinaryType)
                .WithMany(p => p.Pretasks)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });


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
            entity.HasOne(d => d.Pretask)
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

        modelBuilder.Entity<Zap>(entity =>
        {
            entity.HasOne(d => d.Agent).WithMany(p => p.Zaps);

            entity.HasOne(d => d.Hashlist).WithMany(p => p.Zaps).OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
