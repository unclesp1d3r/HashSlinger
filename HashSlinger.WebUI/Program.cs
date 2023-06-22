using HashSlinger.WebUI;
using HashSlinger.WebUI.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddRefitClient<IHashSlingerApi>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri("http://localhost:5090/api/v1");
        c.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher;
    });
builder.Services.AddMudServices();

await builder.Build().RunAsync();
