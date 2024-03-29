﻿namespace HashSlinger.Api.Endpoints.UserApiV1;

using Data;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Shared.Generated;
using Shared.Models;

/// <summary>Holds the handlers for the agent endpoints.</summary>
public static class AgentEndpointHandlers
{
    /// <summary>Handles creating an agent.</summary>
    /// <param name="agent">The agent.</param>
    /// <param name="db">The database.</param>
    /// <returns></returns>
    public async static Task<Created<AgentDto>> CreateAgentHandlerAsync(AgentDto agent, HashSlingerContext db)
    {
        db.Agents.Add(agent.Adapt<Agent>());
        await db.SaveChangesAsync().ConfigureAwait(true);
        return TypedResults.Created($"{UserApiEndPoints.ApiPrefix}/Agent/{agent.Id}", agent);
    }

    /// <summary>Handles deleting an agent.</summary>
    /// <param name="id">The agent identifier.</param>
    /// <param name="db">The database.</param>
    /// <returns>A result indicating whether the agent was deleted or not.</returns>
    public async static Task<Results<Ok, NotFound>> DeleteAgentHandlerAsync(int id, HashSlingerContext db)
    {
        var affected = await db.Agents.Where(model => model.Id == id).ExecuteDeleteAsync().ConfigureAwait(true);

        return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
    }

    /// <summary>Gets the agent by identifier.</summary>
    /// <param name="id">The identifier.</param>
    /// <param name="db">The database.</param>
    /// <returns> The agent with the specified identifier.</returns>
    public async static Task<Results<Ok<AgentDto>, NotFound>> GetAgentByIdHandlerAsync(int id, HashSlingerContext db)
    {
        return await db.Agents.AsNoTracking()
                       .ProjectToType<AgentDto>()
                       .AsSplitQuery()
                       .FirstOrDefaultAsync(model => model.Id == id)
                       .ConfigureAwait(true) is AgentDto model
                   ? TypedResults.Ok(model)
                   : TypedResults.NotFound();
    }

    /// <summary>Gets all agents.</summary>
    /// <param name="db">The database.</param>
    /// <returns>
    ///     <br />
    /// </returns>
    public static Task<List<AgentDto>> GetAllAgentsHandlerAsync(HashSlingerContext db)
    {
        return db.Agents.ProjectToType<AgentDto>().AsSplitQuery().ToListAsync();
    }

    /// <summary>Handles updating an agent.</summary>
    /// <param name="id">The identifier.</param>
    /// <param name="agent">The agent.</param>
    /// <param name="db">The database.</param>
    /// <returns></returns>
    public async static Task<Results<Ok, NotFound>> UpdateAgentHandlerAsync(int id, AgentDto agent, HashSlingerContext db)
    {
        var affected = await db.Agents.Where(model => model.Id == id)
                               .ExecuteUpdateAsync(setters => setters.SetProperty(m => m.Id, agent.Id)
                                                                     .SetProperty(m => m.Name, agent.Name)
                                                                     .SetProperty(m => m.Uid, agent.Uid)
                                                                     .SetProperty(m => m.Devices, agent.Devices)
                                                                     .SetProperty(m => m.CommandParameters,
                                                                         agent.CommandParameters)
                                                                     .SetProperty(m => m.IgnoreErrors, agent.IgnoreErrors)
                                                                     .SetProperty(m => m.IsActive, agent.IsActive)
                                                                     .SetProperty(m => m.IsTrusted, agent.IsTrusted)
                                                                     .SetProperty(m => m.Token, agent.Token)
                                                                     .SetProperty(m => m.LastSeenTime, agent.LastSeenTime)
                                                                     .SetProperty(m => m.UserId, agent.UserId)
                                                                     .SetProperty(m => m.CpuOnly, agent.CpuOnly)
                                                                     .SetProperty(m => m.ClientSignature,
                                                                         agent.ClientSignature))
                               .ConfigureAwait(true);

        return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
    }
}
