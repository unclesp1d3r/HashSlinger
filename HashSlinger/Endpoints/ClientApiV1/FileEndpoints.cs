namespace HashSlinger.Api.Endpoints.ClientApiV1;

using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;
using Services;

/// <summary>Maps endpoints enabling uploads and downloads.</summary>
public static class FileEndpoints
{
    /// <summary>The API prefix</summary>
    public static string ApiPrefix = "/files";

    /// <summary>Maps the file endpoints.</summary>
    /// <param name="routes">The routes.</param>
    /// <remarks>We should definitely protect these somehow.</remarks>
    public static void MapFileEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet(ApiPrefix + "/{bucket}/{name}",
                async (string bucket, string name, IFileStorageService fileStorageService) =>
                {
                    Stream? file = await fileStorageService.GetFileAsync(name, bucket).ConfigureAwait(true);
                    return file is null
                        ? Results.NotFound()
                        : TypedResults.File(file, "application/octet-stream");
                })
            .Produces<FileContentHttpResult>()
            .Produces(StatusCodes.Status404NotFound)
            .WithName("GetFile")
            .WithOpenApi();

        routes.MapPost("/files/{bucket}/{name}",
                async (string bucket, string name, IFormFile file, IFileStorageService fileStorageService) =>
                {
                    if (file is null) return Results.BadRequest();
                    Log.Information("Temp file: {TempFile}", file.Name);
                    await using Stream fileStream = file.OpenReadStream();
                    return await fileStorageService.StoreFileAsync(name, bucket, fileStream)
                        .ConfigureAwait(true)
                        ? Results.Ok()
                        : Results.BadRequest();
                })
            .Accepts<IFormFile>("multipart/form-data")
            .WithName("PutFile");
    }
}
