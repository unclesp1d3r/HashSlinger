namespace HashSlinger.Test;

using Api.Data;
using Api.Utilities;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Shared.Models.Enums;

internal static class Utilities
{
    public const string TestToken = "testToken";
    public const string TestVoucher = "test123456";

    public static void ReinitializeDbForTests(HashSlingerContext db)
    {
        db.RegistrationVouchers.ExecuteDelete();
        db.Agents.ExecuteDelete();
        db.AgentBinaries.ExecuteDelete();
        InitializeDbForTests(db);
    }

    private static void InitializeDbForTests(HashSlingerContext db)
    {
        db.RegistrationVouchers.Add(new RegistrationVoucher
        {
            Voucher = TestVoucher, Expiration = DateTime.UtcNow.AddDays(1)
        });
        db.Agents.Add(new Agent
        {
            Name = "Test Client", Token = TestToken,
            IsActive = true, LastAction = AgentActions.Register
        });
        db.AgentBinaries.Add(new AgentBinary
        {
            Version = "1.0.1", DownloadUrl = "http://example.com",
            Executable = "test.zip",
            OperatingSystems = new List<string> { AgentOperatingSystems.Windows.ToString() },
            Type = "python",
            UpdateAvailable = string.Empty,
            UpdateTrack = "release"
        });
        db.FileDeletes.Add(new FileDelete { FileName = "fake_file.txt", Time = DateTime.UtcNow.AddDays(-1) });

        db.HashTypes.AddRange(SeedTool.GetHashTypeSeeds());

        db.SaveChanges();
    }
}
