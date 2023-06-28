namespace HashSlinger.Api.Endpoints.HashtopolisApiV2;

using Api.Handlers.Queries;
using Data;
using DTO;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
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
                async (HashtopolisRequest request, [FromServices] HashSlingerContext dbContext, IMediator mediator) =>
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
            .Accepts<HashtopolisRequest>(false, "application/json")
            .Produces<CheckClientVersionResponse>()
            .Produces<ClientErrorResponse>()
            .Produces<DeregisterResponse>()
            .Produces<DownloadBinaryResponse>()
            .Produces<GetChunkResponse>()
            .Produces<GetFileResponse>()
            .Produces<GetFileStatusResponse>()
            .Produces<GetHashlistResponse>()
            .Produces<GetHealthCheckResponse>()
            .Produces<GetTaskResponse>()
            .Produces<LoginResponse>()
            .Produces<RegisterResponse>()
            .Produces<SendBenchmarkResponse>()
            .Produces<SendHealthCheckResponse>()
            .Produces<SendKeyspaceResponse>()
            .Produces<SendProgressResponse>()
            .Produces<TestConnectionResponse>()
            .Produces<UpdateInformationResponse>()
            .Produces(StatusCodes.Status400BadRequest);

        group.MapGet("/getHashlist/{id:int}",
                (int id, [FromQuery] string token, IMediator mediator) =>
                    mediator.Send(new GetHashlistDownloadQuery(id, token)))
            .Produces<FileContentHttpResult>()
            .Produces(StatusCodes.Status404NotFound)
            .WithName("DownloadHashlist")
            .WithOpenApi();
    }
}
