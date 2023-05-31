namespace HashSlinger.Api.Endpoints.HashtopolisApiV2;

using Data;
using Microsoft.AspNetCore.Mvc;

/// <summary>
///     Maps the endpoints for the Hashtopolis API.
///     <remarks>
///         This is just an adapter for the Hashtopolis Communication Protocol V2 and does not implement every
///         feature of Hashtopolis.
///     </remarks>
/// </summary>
public static class HashtopolisEndpoints
{
    /// <summary>Maps the hashtopolis endpoints.</summary>
    /// <param name="routes">The routes.</param>
    public static void MapHashtopolisEndpoints(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder group = routes.MapGroup("/api/Hashtopolis");

        group.MapPost("/",
                async (
                    HashtopolisRequest request,
                    [FromServices] HashSlingerContext db,
                    [FromServices] ILoggerFactory loggerFactory
                ) =>
                {
                    ILogger logger = loggerFactory.CreateLogger("Hashtopolis API");
                    logger.LogDebug("New request: {@request}");
                    IHashtopolisRequest? message = request.ToHashtopolisRequest();
                    if (message is null)
                    {
                        HashtopolisRequest? badRequest = request with { Response = "ERROR" };
                        logger.LogError("Bad API request: {@badRequest}", badRequest);
                        return Results.BadRequest(badRequest);
                    }

                    // The result would never be null, because the spec says that a bad request should just
                    // return a 200 with an error message.
                    IHashtopolisMessage result
                        = await message.ProcessRequestAsync(db, logger).ConfigureAwait(true);
                    return Results.Ok(result);
                })
            .Accepts<HashtopolisRequest>("application/json")
            .Produces<IHashtopolisMessage>()
            .Produces(400)
            .Produces(401);
    }
}
