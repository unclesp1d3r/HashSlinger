namespace HashSlinger.Api.Endpoints.UserApiV1;

using Data;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Shared.Generated;
using Shared.Models;

/// <summary>Holds the handlers for the agent binary endpoints.</summary>
public static class AgentBinariesEndpointHandlers
{
    /// <summary>Handles creating an agent binary.</summary>
    /// <param name="agentBinary">The agent binary.</param>
    /// <param name="db">The database.</param>
    /// <returns></returns>
    public async static Task<Created<AgentBinaryDto>> CreateAgentBinaryHandlerAsync(
        AgentBinaryDto agentBinary,
        HashSlingerContext db
    )
    {
        db.AgentBinaries.Add(agentBinary.Adapt<AgentBinary>());
        await db.SaveChangesAsync().ConfigureAwait(true);
        return TypedResults.Created($"{UserApiEndPoints.ApiPrefix}/AgentBinary/{agentBinary.Id}", agentBinary);
    }

    /// <summary>Handles deleting an agent binary.</summary>
    /// <param name="id">The identifier.</param>
    /// <param name="db">The database.</param>
    /// <returns></returns>
    public async static Task<Results<Ok, NotFound>> DeleteAgentBinaryHandlerAsync(int id, HashSlingerContext db)
    {
        var affected = await db.AgentBinaries.Where(model => model.Id == id).ExecuteDeleteAsync().ConfigureAwait(true);

        return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
    }

    /// <summary>Handles getting an agent binary by id.</summary>
    /// <param name="id">The identifier.</param>
    /// <param name="db">The database.</param>
    /// <returns></returns>
    public async static Task<Results<Ok<AgentBinaryDto>, NotFound>> GetAgentBinaryByIdHandlerAsync(
        int id,
        HashSlingerContext db
    )
    {
        return await db.AgentBinaries.ProjectToType<AgentBinaryDto>()
            .AsNoTracking()
            .AsSplitQuery()
            .FirstOrDefaultAsync(model => model.Id == id)
            .ConfigureAwait(true) is AgentBinaryDto model
            ? TypedResults.Ok(model)
            : TypedResults.NotFound();
    }

    /// <summary>Handles getting all agent binaries.</summary>
    /// <param name="db">The database.</param>
    /// <returns></returns>
    public static Task<List<AgentBinaryDto>> GetAllAgentBinariesHandlerAsync(HashSlingerContext db)
    {
        return db.AgentBinaries.ProjectToType<AgentBinaryDto>().AsSplitQuery().ToListAsync();
    }

    /// <summary>Handles updating an agent binary.</summary>
    /// <param name="id">The identifier.</param>
    /// <param name="agentBinary">The agent binary.</param>
    /// <param name="db">The database.</param>
    /// <returns></returns>
    public async static Task<Results<Ok, NotFound>> UpdateAgentBinaryHandlerAsync(
        int id,
        AgentBinaryDto agentBinary,
        HashSlingerContext db
    )
    {
        var affected = await db.AgentBinaries.Where(model => model.Id == id)
            .ExecuteUpdateAsync(setters => setters.SetProperty(m => m.Type, agentBinary.Type)
                .SetProperty(m => m.UpdateAvailable, agentBinary.UpdateAvailable)
                .SetProperty(m => m.UpdateTrack, agentBinary.UpdateTrack)
                .SetProperty(m => m.DownloadUrl, agentBinary.DownloadUrl)
                .SetProperty(m => m.Executable, agentBinary.Executable)
                .SetProperty(m => m.Id, agentBinary.Id)
                .SetProperty(m => m.Name, agentBinary.Name)
                .SetProperty(m => m.OperatingSystems, agentBinary.OperatingSystems)
                .SetProperty(m => m.Version, agentBinary.Version))
            .ConfigureAwait(true);

        return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
    }
}
