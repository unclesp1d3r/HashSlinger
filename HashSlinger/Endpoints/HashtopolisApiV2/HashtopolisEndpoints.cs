namespace HashSlinger.Api.Endpoints.HashtopolisApiV2;

/// <summary>
/// Maps the endpoints for the Hashtopolis API.
/// </summary>
public static class HashtopolisEndpoints
{
    /// <summary>Maps the hashtopolis endpoints.</summary>
    /// <param name="routes">The routes.</param>
    public static void MapHashtopolisEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Hashtopolis");

        group.MapGet("/", () => "TODO!")
            .WithOpenApi();
        ;
    }
}
