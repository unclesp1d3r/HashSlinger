namespace HashSlinger.Test;

using Api.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class MyWebApplicationFactory : WebApplicationFactory<Program>
{
    /// <inheritdoc />
    protected override IHost CreateHost(IHostBuilder builder)
    {
        var root = new InMemoryDatabaseRoot();
        builder.ConfigureServices(services =>
        {
            services.AddScoped(sp => services.AddDbContext<HashSlingerContext>(options =>
                options.UseInMemoryDatabase("HashSlingerContext", root)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
                    .UseApplicationServiceProvider(sp)));
        });


        return base.CreateHost(builder);
    }
}
