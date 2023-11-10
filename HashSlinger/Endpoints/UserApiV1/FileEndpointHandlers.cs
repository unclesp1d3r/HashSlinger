namespace HashSlinger.Api.Endpoints.UserApiV1;

using Data;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Shared.Generated;
using Shared.Models;
using Shared.Models.Enums;

/// <summary>
/// Holds the handlers for the file endpoints.
/// </summary>
public static class FileEndpointHandlers
{
    /// <summary>
    /// Handles deleting a file.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="db">The database.</param>
    /// <returns></returns>
    public async static Task<Results<Ok, NotFound>> DeleteFileHandlerAsync(int id, HashSlingerContext db)
    {
        var affected = await db.Files.Where(model => model.Id == id).ExecuteDeleteAsync().ConfigureAwait(true);

        return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
    }

    /// <summary>
    /// Handles creating a file.
    /// </summary>
    /// <param name="file">The file.</param>
    /// <param name="db">The database.</param>
    /// <returns></returns>
    public async static Task<Created<FileDto>> CreateFileHandlerAsync(FileDto file, HashSlingerContext db)
    {
        db.Files.Add(file.Adapt<File>());
        await db.SaveChangesAsync().ConfigureAwait(true);
        return TypedResults.Created($"{UserApiEndPoints.ApiPrefix}/File/{file.Id}", file);
    }

    /// <summary>
    /// Handles updating a file.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="file">The file.</param>
    /// <param name="db">The database.</param>
    /// <returns></returns>
    public async static Task<Results<Ok, NotFound>> UpdateFileHandlerAsync(int id, FileDto file, HashSlingerContext db)
    {
        var affected = await db.Files.Where(model => model.Id == id)
                               .ExecuteUpdateAsync(setters => setters.SetProperty(m => m.AccessGroupId, file.AccessGroupId)
                                                                     .SetProperty(m => m.FileGuid, file.FileGuid)
                                                                     .SetProperty(m => m.FileName, file.FileName)
                                                                     .SetProperty(m => m.FileType,
                                                                         file.FileType.Adapt<FileType>())
                                                                     .SetProperty(m => m.Id, file.Id)
                                                                     .SetProperty(m => m.IsSecret, file.IsSecret)
                                                                     .SetProperty(m => m.LineCount, file.LineCount)
                                                                     .SetProperty(m => m.Size, file.Size))
                               .ConfigureAwait(true);

        return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
    }

    /// <summary>
    /// Handles getting a file by its identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="db">The database.</param>
    /// <returns></returns>
    public async static Task<Results<Ok<FileDto>, NotFound>> GetFileByIdHandlerAsync(int id, HashSlingerContext db)
    {
        return await db.Files.ProjectToType<FileDto>()
                       .AsNoTracking()
                       .FirstOrDefaultAsync(model => model.Id == id)
                       .ConfigureAwait(true) is FileDto model
                   ? TypedResults.Ok(model)
                   : TypedResults.NotFound();
    }

    /// <summary>
    /// Handles getting all files.
    /// </summary>
    /// <param name="db">The database.</param>
    /// <returns></returns>
    public static Task<List<FileDto>> GetAllFilesHandlerAsync(HashSlingerContext db)
    {
        return db.Files.ProjectToType<FileDto>().ToListAsync();
    }
}
