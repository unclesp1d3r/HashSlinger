namespace HashSlinger.Test;

using System.Data.Common;
using Api.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

internal class MyWebApplicationFactory : WebApplicationFactory<Program>
{
    /// <summary>The connection string</summary>
    /// <remarks>This is just a bad way to do it. I can't find another way.</remarks>
    private const string ConnectionString
        = "Host=localhost;Port=5432;Database=HashSlinger_Dev;Username=postgres;Password=postgres";

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            ServiceDescriptor? dbContextDescriptor = services.SingleOrDefault(d =>
                d.ServiceType == typeof(DbContextOptions<HashSlingerContext>));

            services.Remove(dbContextDescriptor!);

            ServiceDescriptor? dbConnectionDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbConnection));

            services.Remove(dbConnectionDescriptor!);

            services.AddDbContext<HashSlingerContext>(options =>
                options.UseNpgsql(ConnectionString).EnableSensitiveDataLogging().EnableDetailedErrors());
        });

        builder.UseEnvironment("Development");
    }
}
