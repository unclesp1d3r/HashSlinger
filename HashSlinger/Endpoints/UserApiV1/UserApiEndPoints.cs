namespace HashSlinger.Api.Endpoints.UserApiV1;

using Data;
using Generated;
using Handlers.Commands;
using Handlers.Queries;
using Mapster;
using MediatR;
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
        RouteGroupBuilder group = routes.MapGroup($"{ApiPrefix}/Agent").WithTags(nameof(Agent));

        group.MapGet("/", (HashSlingerContext db) => db.Agents.ProjectToType<AgentDto>().ToListAsync())
            .WithName("GetAllAgents")
            .WithOpenApi();

        group.MapGet("/{id:int}",
                async Task<Results<Ok<AgentDto>, NotFound>> (int id, IMediator mediator) =>
                {
                    Agent? agent = await mediator.Send(new GetAgentByIdQuery(id)).ConfigureAwait(true);
                    return agent is null ? TypedResults.NotFound() : TypedResults.Ok(agent.Adapt<AgentDto>());
                })
            .WithName("GetAgentById")
            .WithOpenApi();

        group.MapPut("/{id:int}",
                async Task<Results<Ok, NotFound>> (int id, AgentDto agent, HashSlingerContext db) =>
                {
                    var affected = await db.Agents.Where(model => model.Id == id)
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
                    var affected = await db.Agents.Where(model => model.Id == id).ExecuteDeleteAsync().ConfigureAwait(true);

                    return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
                })
            .WithName("DeleteAgent")
            .WithOpenApi();

        // Mostly for testing. This is not part of the final API.
        group.MapPost("/initial-setup", (IMediator mediator) => { mediator.Send(new PerformInitialSetupCommand()); })
            .WithOpenApi();
    }
}
