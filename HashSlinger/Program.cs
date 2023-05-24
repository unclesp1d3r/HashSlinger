using HashSlinger.Api.Data;
using HashSlinger.Api.Endpoints.HashtopolisApiV2;
using HashSlinger.Api.Endpoints.User;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HashSlingerContext>(options =>
    options.UseNpgsql(builder.Configuration["HashSlingerContext"]));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapUserEndpoints();

app.MapHashtopolisEndpoints();

app.Run();
