namespace HashSlinger.Api.Endpoints.HashtopolisApiV2;

using Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
        RouteGroupBuilder group = routes.MapGroup(HashtopolisConstants.EndPointPrefix);

        group.MapPost("/",
                async (
                    HashtopolisRequest request,
                    [FromServices] HashSlingerContext dbContext,
                    IMediator mediator,
                    HttpContext context
                ) =>
                {
                    Log.Information("New request: {@Request}", request);

                    IHashtopolisRequest? message = HashtopolisRequest.ToHashtopolisRequest(request);
                    if (message is null)
                    {
                        HashtopolisRequest badRequest = request with { Response = "ERROR" };
                        Log.Error("Bad API request: {@BadRequest}", badRequest);
                        return Results.BadRequest(badRequest);
                    }

                    var result = await mediator.Send(message).ConfigureAwait(true);
                    Log.Information("Result: {@Result}", result);
                    return Results.Ok(result);
                })
            .Accepts<HashtopolisRequest>("application/json")
            .Produces<IHashtopolisMessage>()
            .Produces(400)
            .Produces(401);
    }
}
