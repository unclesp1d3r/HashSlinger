namespace HashSlinger.Api.Endpoints.ClientApiV1;

using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;
using Services;

/// <summary>Maps endpoints enabling uploads and downloads.</summary>
public static class FileEndpoints
{
    public static string ApiPrefix = "/files";

    /// <summary>Maps the file endpoints.</summary>
    /// <param name="routes">The routes.</param>
    /// <remarks>We should definitely protect these somehow.</remarks>
    public static void MapFileEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet(ApiPrefix + "/{bucket}/{fileId:guid}",
                async (string bucket, Guid fileId, IFileStorageService fileStorageService) =>
                {
                    Stream? file = await fileStorageService.GetFileAsync(fileId, bucket).ConfigureAwait(true);
                    if (file == null) return Results.NotFound();
                    return TypedResults.File(file, "application/octet-stream");
                })
            .Produces<FileContentHttpResult>()
            .Produces(StatusCodes.Status404NotFound)
            .WithName("GetFile")
            .WithOpenApi();

        routes.MapPost("/files/{bucket}/{fileId:guid}",
                async (string bucket, Guid fileId, IFormFile file, IFileStorageService fileStorageService) =>
                {
                    if (file == null) return Results.BadRequest();
                    Log.Information("Temp file: {TempFile}", file.Name);
                    await using Stream fileStream = file.OpenReadStream();
                    return await fileStorageService.StoreFileAsync(fileId, bucket, fileStream)
                        .ConfigureAwait(true)
                        ? Results.Ok()
                        : Results.BadRequest();
                })
            .Accepts<IFormFile>("multipart/form-data")
            .WithName("PutFile");
    }
}
