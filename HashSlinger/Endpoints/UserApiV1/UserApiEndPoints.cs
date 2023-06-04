namespace HashSlinger.Api.Endpoints.UserApiV1;

using Data;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Models;
using Shared.DTO;
using Utilities;

/// <summary>Contains the version 1 API for user interface functionality.</summary>
public static class UserApiEndPoints
{
    private static readonly string ApiPrefix = "/api/v1";


    /// <summary>Maps the agent endpoints.</summary>
    /// <param name="routes">The routes.</param>
    public static void MapAgentEndpoints(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder? group = routes.MapGroup($"{ApiPrefix}/Agent").WithTags(nameof(Agent));

        group.MapGet("/", (HashSlingerContext db) => db.Agents.ToListAsync())
            .WithName("GetAllAgents")
            .WithOpenApi();

        group.MapGet("/{id}",
                async Task<Results<Ok<Agent>, NotFound>> (int id, HashSlingerContext db) =>
                {
                    return await db.Agents.AsNoTracking()
                        .FirstOrDefaultAsync(model => model.Id == id)
                        .ConfigureAwait(true) is Agent model
                        ? TypedResults.Ok(model)
                        : TypedResults.NotFound();
                })
            .WithName("GetAgentById")
            .WithOpenApi();

        group.MapPut("/{id}",
                async Task<Results<Ok, NotFound>> (int id, Agent agent, HashSlingerContext db) =>
                {
                    int affected = await db.Agents.Where(model => model.Id == id)
                        .ExecuteUpdateAsync(setters => setters.SetProperty(m => m.Id, agent.Id)
                            .SetProperty(m => m.Name, agent.Name)
                            .SetProperty(m => m.Uid, agent.Uid)
                            .SetProperty(m => m.OperatingSystem, agent.OperatingSystem)
                            .SetProperty(m => m.Devices, agent.Devices)
                            .SetProperty(m => m.CommandParameters, agent.CommandParameters)
                            .SetProperty(m => m.IgnoreErrors, agent.IgnoreErrors)
                            .SetProperty(m => m.IsActive, agent.IsActive)
                            .SetProperty(m => m.IsTrusted, agent.IsTrusted)
                            .SetProperty(m => m.Token, agent.Token)
                            .SetProperty(m => m.LastAction, agent.LastAction)
                            .SetProperty(m => m.LastSeenTime, agent.LastSeenTime)
                            .SetProperty(m => m.LastIp, agent.LastIp)
                            .SetProperty(m => m.UserId, agent.UserId)
                            .SetProperty(m => m.CpuOnly, agent.CpuOnly)
                            .SetProperty(m => m.ClientSignature, agent.ClientSignature))
                        .ConfigureAwait(true);

                    return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
                })
            .WithName("UpdateAgent")
            .WithOpenApi();

        group.MapPost("/",
                async (Agent agent, HashSlingerContext db) =>
                {
                    db.Agents.Add(agent);
                    await db.SaveChangesAsync().ConfigureAwait(true);
                    return TypedResults.Created($"{ApiPrefix}/Agent/{agent.Id}", agent);
                })
            .WithName("CreateAgent")
            .WithOpenApi();

        group.MapDelete("/{id}",
                async Task<Results<Ok, NotFound>> (int id, HashSlingerContext db) =>
                {
                    int affected = await db.Agents.Where(model => model.Id == id)
                        .ExecuteDeleteAsync()
                        .ConfigureAwait(true);

                    return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
                })
            .WithName("DeleteAgent")
            .WithOpenApi();
    }

    /// <summary>Maps the user endpoints.</summary>
    /// <param name="routes">The routes.</param>
    public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder? group = routes.MapGroup($"{ApiPrefix}/User").WithTags(nameof(UserDto));

        group.MapGet("/", (HashSlingerContext db) => db.Users.ProjectToType<UserDto>().ToListAsync())
            .WithName("GetAllUsers")
            .WithOpenApi();

        group.MapGet("/{id}",
                async Task<Results<Ok<UserDto>, NotFound>> (int id, HashSlingerContext db) =>
                {
                    return await db.Users.AsNoTracking()
                        .ProjectToType<UserDto>()
                        .FirstOrDefaultAsync(model => model.Id == id)
                        .ConfigureAwait(true) is UserDto model
                        ? TypedResults.Ok(model)
                        : TypedResults.NotFound();
                })
            .WithName("GetUserById")
            .WithOpenApi();

        group.MapPut("/{id}",
                async Task<Results<Ok, NotFound>> (int id, UserDto user, HashSlingerContext db) =>
                {
                    if (user.Password != null)
                        (user.PasswordHash, user.PasswordSalt) = Authentication.HashPassword(user.Password);
                    int affected = await db.Users.Where(model => model.Id == id)
                        .ExecuteUpdateAsync(setters => setters.SetProperty(m => m.Id, user.Id)
                            .SetProperty(m => m.UserName, user.UserName)
                            .SetProperty(m => m.Email, user.Email)
                            .SetProperty(m => m.PasswordHash, user.PasswordHash)
                            .SetProperty(m => m.PasswordSalt, user.PasswordSalt)
                            .SetProperty(m => m.IsValid, user.IsValid)
                            .SetProperty(m => m.LastLoginDate, user.LastLoginDate)
                            .SetProperty(m => m.RegisteredSince, user.RegisteredSince))
                        .ConfigureAwait(true);

                    return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
                })
            .WithName("UpdateUser")
            .WithOpenApi();

        group.MapPost("/",
                async (UserDto user, HashSlingerContext db) =>
                {
                    var u = user.Adapt<User>();
                    if (user.Password != null) u.SetPasswordHash(user.Password);
                    db.Users.Add(u);
                    int affected = await db.SaveChangesAsync().ConfigureAwait(true);
                    return TypedResults.Created($"{ApiPrefix}/User/{user.Id}", user);
                })
            .WithName("CreateUser")
            .WithOpenApi();

        group.MapDelete("/{id}",
                async Task<Results<Ok, NotFound>> (int id, HashSlingerContext db) =>
                {
                    int affected = await db.Users.Where(model => model.Id == id)
                        .ExecuteDeleteAsync()
                        .ConfigureAwait(true);

                    return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
                })
            .WithName("DeleteUser")
            .WithOpenApi();
    }
}
