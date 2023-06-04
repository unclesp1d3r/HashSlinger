using HashSlinger.Api.DAL;
using HashSlinger.Api.Data;
using HashSlinger.Api.Endpoints.HashtopolisApiV2;
using HashSlinger.Api.Endpoints.UserApiV1;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration().WriteTo.Console(LogEventLevel.Information)
    .MinimumLevel.Debug()
    .WriteTo.File("Log/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HashSlingerContext>(options =>
    options.UseNpgsql(builder.Configuration["HashSlingerContext"])
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());
builder.Services.AddSingleton(new Repository());


builder.Host.UseSerilog();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

;

app.UseHttpsRedirection();

app.MapHashtopolisEndpoints();


app.MapAgentEndpoints();

app.MapUserEndpoints();

app.Run();

/// <summary>The main program for the minimal API.</summary>
/// <remarks>This is required for the testing project to work</remarks>
public partial class Program { }
