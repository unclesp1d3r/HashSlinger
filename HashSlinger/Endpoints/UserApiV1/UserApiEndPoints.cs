namespace HashSlinger.Api.Endpoints.UserApiV1;

using Data;
using Generated;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Models;

/// <summary>Contains the version 1 API for user interface functionality.</summary>
public static class UserApiEndPoints
{
    private const string ApiPrefix = "/api/v1";


    /// <summary>Maps the agent endpoints.</summary>
    /// <param name="routes">The routes.</param>
    public static void MapAgentEndpoints(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder? group = routes.MapGroup($"{ApiPrefix}/Agent").WithTags(nameof(Agent));

        group.MapGet("/", (HashSlingerContext db) => db.Agents.ProjectToType<AgentDto>().ToListAsync())
            .WithName("GetAllAgents")
            .WithOpenApi();

        group.MapGet("/{id}",
                async Task<Results<Ok<AgentDto>, NotFound>> (int id, HashSlingerContext db) =>
                {
                    return await db.Agents.AsNoTracking()
                        .ProjectToType<AgentDto>()
                        .FirstOrDefaultAsync(a => a.Id == id)
                        .ConfigureAwait(true) is AgentDto model
                        ? TypedResults.Ok(model)
                        : TypedResults.NotFound();
                })
            .WithName("GetAgentById")
            .WithOpenApi();

        group.MapPut("/{id}",
                async Task<Results<Ok, NotFound>> (int id, AgentDto agent, HashSlingerContext db) =>
                {
                    int affected = await db.Agents.Where(model => model.Id == id)
                        .ExecuteUpdateAsync(setters => setters.SetProperty(m => m.Id, agent.Id)
                            .SetProperty(m => m.Name, agent.Name)
                            .SetProperty(m => m.Uid, agent.Uid)
                            .SetProperty(m => m.Devices, agent.Devices)
                            .SetProperty(m => m.CommandParameters, agent.CommandParameters)
                            .SetProperty(m => m.IgnoreErrors, agent.IgnoreErrors)
                            .SetProperty(m => m.IsActive, agent.IsActive)
                            .SetProperty(m => m.IsTrusted, agent.IsTrusted)
                            .SetProperty(m => m.Token, agent.Token)
                            .SetProperty(m => m.LastSeenTime, agent.LastSeenTime)
                            .SetProperty(m => m.UserId, agent.UserId)
                            .SetProperty(m => m.CpuOnly, agent.CpuOnly)
                            .SetProperty(m => m.ClientSignature, agent.ClientSignature))
                        .ConfigureAwait(true);

                    return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
                })
            .WithName("UpdateAgent")
            .WithOpenApi();

        group.MapPost("/",
                async (AgentDto agent, HashSlingerContext db) =>
                {
                    db.Agents.Add(agent.Adapt<Agent>());
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

        // Mostly for testing. This is not part of the final API.
        group.MapPost("/initial-setup",
                (HashSlingerContext db) =>
                {
                    // Clean up the database.
                    db.Agents.RemoveRange(db.Agents);
                    db.Users.RemoveRange(db.Users);
                    db.RegistrationVouchers.RemoveRange(db.RegistrationVouchers);
                    db.AccessGroups.RemoveRange(db.AccessGroups);
                    db.SaveChanges();

                    var defaultGroup = new AccessGroup { Name = "Default" };
                    db.AccessGroups.Add(defaultGroup);
                    var admin = new User
                    {
                        Email = "admin@localhost", UserName = "admin",
                        RegisteredSince = DateTime.UtcNow
                    };
                    admin.SetPasswordHash("admin");
                    defaultGroup.Users.Add(admin);
                    db.Users.Add(admin);
                    db.RegistrationVouchers.Add(new RegistrationVoucher
                    { Voucher = "abcd", AccessGroup = defaultGroup });
                    db.SaveChanges();
                })
            .WithOpenApi();
    }
}
