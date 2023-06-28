namespace HashSlinger.Api.Endpoints.UserApiV1;

using Data;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Shared.Generated;
using Shared.Models;

/// <summary>Holds the handlers for the cracker binaries endpoints.</summary>
public static class CrackerBinariesEndpointHandler
{
    /// <summary>Handles creating a cracker binary.</summary>
    /// <param name="crackerBinary">The cracker binary.</param>
    /// <param name="db">The database.</param>
    /// <returns></returns>
    public async static Task<Created<CrackerBinaryDto>> CreateCrackerBinaryHandlerAsync(
        CrackerBinaryDto crackerBinary,
        HashSlingerContext db
    )
    {
        db.CrackerBinaries.Add(crackerBinary.Adapt<CrackerBinary>());
        await db.SaveChangesAsync().ConfigureAwait(true);
        return TypedResults.Created($"{UserApiEndPoints.ApiPrefix}/CrackerBinary/{crackerBinary.Id}", crackerBinary);
    }

    /// <summary>Handles deleting a cracker binary.</summary>
    /// <param name="id">The identifier.</param>
    /// <param name="db">The database.</param>
    /// <returns></returns>
    public async static Task<Results<Ok, NotFound>> DeleteCrackerBinaryHandlerAsync(int id, HashSlingerContext db)
    {
        var affected = await db.CrackerBinaries.Where(model => model.Id == id).ExecuteDeleteAsync().ConfigureAwait(true);

        return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
    }

    /// <summary>Handles getting all cracker binaries.</summary>
    /// <param name="db">The database.</param>
    /// <returns></returns>
    public static Task<List<CrackerBinaryDto>> GetAllCrackerBinariesHandlerAsync(HashSlingerContext db)
    {
        return db.CrackerBinaries.ProjectToType<CrackerBinaryDto>().AsSplitQuery().ToListAsync();
    }

    /// <summary>Handles getting a cracker binary by id.</summary>
    /// <param name="id">The identifier.</param>
    /// <param name="db">The database.</param>
    /// <returns></returns>
    public async static Task<Results<Ok<CrackerBinaryDto>, NotFound>> GetCrackerBinaryByIdHandlerAsync(
        int id,
        HashSlingerContext db
    )
    {
        return await db.CrackerBinaries.ProjectToType<CrackerBinaryDto>()
            .AsNoTracking()
            .AsSplitQuery()
            .FirstOrDefaultAsync(model => model.Id == id)
            .ConfigureAwait(true) is CrackerBinaryDto model
            ? TypedResults.Ok(model)
            : TypedResults.NotFound();
    }

    /// <summary>Handles updating a cracker binary.</summary>
    /// <param name="id">The identifier.</param>
    /// <param name="crackerBinary">The cracker binary.</param>
    /// <param name="db">The database.</param>
    /// <returns></returns>
    public async static Task<Results<Ok, NotFound>> UpdateCrackerBinaryHandlerAsync(
        int id,
        CrackerBinaryDto crackerBinary,
        HashSlingerContext db
    )
    {
        var affected = await db.CrackerBinaries.Where(model => model.Id == id)
            .ExecuteUpdateAsync(setters => setters.SetProperty(m => m.DownloadUrl, crackerBinary.DownloadUrl)
                .SetProperty(m => m.Executable, crackerBinary.Executable)
                .SetProperty(m => m.Id, crackerBinary.Id)
                .SetProperty(m => m.Name, crackerBinary.Name)
                .SetProperty(m => m.OperatingSystems, crackerBinary.OperatingSystems)
                .SetProperty(m => m.Version, crackerBinary.Version))
            .ConfigureAwait(true);

        return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
    }
}
