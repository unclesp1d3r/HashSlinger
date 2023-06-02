namespace HashSlinger.Api.Endpoints.UserApiV1;

using DAL;
using HashSlinger.Api.Data;
using Microsoft.AspNetCore.Mvc;

/// <summary>Contains the version 1 API for user interface functionality.</summary>
public static class UserApiEndPoints
{
    /// <summary>Maps the user API endpoints.</summary>
    /// <param name="routes">The routes.</param>
    public static void MapUserApiEndpoints(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder group = routes.MapGroup("/api/user/v1");
        group.MapPost("/",
            ([FromServices] Repository repository, [FromServices] HashSlingerContext dbContext) =>
            {
                repository.DbContext = dbContext; // This is a terrible hack, but it works.

                return Task.FromResult(Results.Ok("Not implemented yet."));
            });
    }
}
