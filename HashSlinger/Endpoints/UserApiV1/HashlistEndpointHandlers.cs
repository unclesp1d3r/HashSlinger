namespace HashSlinger.Api.Endpoints.UserApiV1;

using Data;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Shared.Generated;
using Shared.Models;
using Shared.Models.Enums;

/// <summary>Holds the handlers for the Hashlist endpoints</summary>
public static class HashlistEndpointHandlers
{
    /// <summary>Handles creating a Hashlist POST /api/v1/Hashlist</summary>
    /// <param name="hashlist">The hashlist.</param>
    /// <param name="db">The database.</param>
    /// <returns></returns>
    public async static Task<Created<HashlistDto>> CreateHashlistHandlerAsync(HashlistDto hashlist, HashSlingerContext db)
    {
        db.Hashlists.Add(hashlist.Adapt<Hashlist>());
        await db.SaveChangesAsync().ConfigureAwait(true);
        return TypedResults.Created($"{UserApiEndPoints.ApiPrefix}/Hashlist/{hashlist.Id}", hashlist);
    }

    /// <summary>Handles deleting a Hashlist DELETE /api/v1/Hashlist/{id}</summary>
    /// <param name="id">The identifier.</param>
    /// <param name="db">The database.</param>
    /// <returns></returns>
    public async static Task<Results<Ok, NotFound>> DeleteHashlistHandlerAsync(int id, HashSlingerContext db)
    {
        var affected = await db.Hashlists.Where(model => model.Id == id).ExecuteDeleteAsync().ConfigureAwait(true);

        return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
    }

    /// <summary>Handles getting all Hashlists GET /api/v1/Hashlist</summary>
    /// <param name="db">The database.</param>
    /// <returns></returns>
    public static Task<List<HashlistDto>> GetAllHashlistsHandlerAsync(HashSlingerContext db)
    {
        return db.Hashlists.ProjectToType<HashlistDto>().AsSplitQuery().ToListAsync();
    }

    /// <summary>Handles getting a Hashlist by id GET /api/v1/Hashlist/{id}</summary>
    /// <param name="id">The identifier.</param>
    /// <param name="db">The database.</param>
    /// <returns></returns>
    public async static Task<Results<Ok<HashlistDto>, NotFound>> GetHashlistByIdHandlerAsync(int id, HashSlingerContext db)
    {
        return await db.Hashlists.AsNoTracking()
            .ProjectToType<HashlistDto>()
            .AsSplitQuery()
            .FirstOrDefaultAsync(model => model.Id == id)
            .ConfigureAwait(true) is HashlistDto model
            ? TypedResults.Ok(model)
            : TypedResults.NotFound();
    }

    /// <summary>Handles updating a Hashlist PUT /api/v1/Hashlist/{id}</summary>
    /// <param name="id">The identifier.</param>
    /// <param name="hashlist">The hashlist.</param>
    /// <param name="db">The database.</param>
    /// <returns></returns>
    public async static Task<Results<Ok, NotFound>> UpdateHashlistHandlerAsync(
        int id,
        HashlistDto hashlist,
        HashSlingerContext db
    )
    {
        var affected = await db.Hashlists.Where(model => model.Id == id)
            .ExecuteUpdateAsync(setters => setters.SetProperty(m => m.BrainFeatures, hashlist.BrainFeatures)
                .SetProperty(m => m.BrainId, hashlist.BrainId)
                .SetProperty(m => m.Cracked, hashlist.Cracked)
                .SetProperty(m => m.Format, hashlist.Format.Adapt<HashListFormats>())
                .SetProperty(m => m.HashCount, hashlist.HashCount)
                .SetProperty(m => m.HexSalt, hashlist.HexSalt)
                .SetProperty(m => m.Id, hashlist.Id)
                .SetProperty(m => m.IsArchived, hashlist.IsArchived)
                .SetProperty(m => m.IsSalted, hashlist.IsSalted)
                .SetProperty(m => m.IsSecret, hashlist.IsSecret)
                .SetProperty(m => m.Name, hashlist.Name)
                .SetProperty(m => m.Notes, hashlist.Notes)
                .SetProperty(m => m.SaltSeparator, hashlist.SaltSeparator))
            .ConfigureAwait(true);

        return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
    }
}
