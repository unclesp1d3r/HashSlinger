namespace HashSlinger.Api.Endpoints.UserApiV1;

/// <summary>Contains the version 1 API for user interface functionality.</summary>
public static class UserApiEndPoints
{
    /// <summary>Maps the user API endpoints.</summary>
    /// <param name="routes">The routes.</param>
    public static void MapUserApiEndpoints(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder group = routes.MapGroup("/api/user/v1");
    }
}
