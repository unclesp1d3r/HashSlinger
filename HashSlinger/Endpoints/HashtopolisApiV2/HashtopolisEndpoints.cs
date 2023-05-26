namespace HashSlinger.Api.Endpoints.HashtopolisApiV2;

/// <summary>
///     Maps the endpoints for the Hashtopolis API.
///     <remarks>
///         This is just an adapter for the Hashtopolis Communication Protocol V2 and does not implement every feature
///         of Hashtopolis.
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
                (HashtopolisRequest request) =>
                {
                    IHashtopolisRequest? message = request.ToHashtopolisRequest();
                    if (message is null)
                    {
                        HashtopolisRequest? badRequest = request with { Response = "ERROR" };
                        return Results.BadRequest(badRequest);
                    }

                    // The result would never be null, because the spec says that a bad request should just
                    // return a 200 with an error message.
                    IHashtopolisMessage result = message.ProcessRequest();
                    return Results.Ok(result);
                })
            .Accepts<HashtopolisRequest>("application/json")
            .Produces<IHashtopolisMessage>()
            .Produces(400)
            .Produces(401);
    }
}
