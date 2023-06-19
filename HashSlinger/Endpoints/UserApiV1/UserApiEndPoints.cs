namespace HashSlinger.Api.Endpoints.UserApiV1;

using Generated;
using Handlers.Commands;
using MediatR;
using Models;

/// <summary>Contains the version 1 API for user interface functionality.</summary>
public static class UserApiEndPoints
{
    public const string ApiPrefix = "/api/v1";

    /// <summary>Maps the user API endpoints.</summary>
    /// <param name="routes">The routes.</param>
    public static void MapUserApiEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapAgentEndpoints();
        routes.MapUtilityEndpoints();
    }

    /// <summary>Maps the utility endpoints.</summary>
    /// <param name="routes">The routes.</param>
    public static void MapUtilityEndpoints(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder group = routes.MapGroup($"{ApiPrefix}/Utils").WithTags("Utils");
        // Mostly for testing. This is not part of the final API.
        group.MapPost("/initial-setup", (IMediator mediator) => { mediator.Send(new PerformInitialSetupCommand()); })
            .WithOpenApi();

        // Mostly for testing. This is not part of the final API.
        group.MapPost("/create-health-check",
                (IMediator mediator) => { mediator.Send(new AssignAllAgentsHealthCheckCommand()); })
            .WithOpenApi();
    }

    /// <summary>Maps the agent endpoints.</summary>
    /// <param name="routes">The routes.</param>
    internal static void MapAgentEndpoints(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder group = routes.MapGroup($"{ApiPrefix}/Agent").WithTags(nameof(Agent));

        group.MapGet("/", AgentEndpointHandlers.GetAllAgentsHandlerAsync).WithName("GetAllAgents").WithOpenApi();

        group.MapGet("/{id:int}", AgentEndpointHandlers.GetAgentByIdHandlerAsync)
            .WithName("GetAgentById")
            .Accepts<int>(false, "The agent identifier.")
            .WithOpenApi();

        group.MapPut("/{id:int}", AgentEndpointHandlers.UpdateAgentHandlerAsync)
            .Accepts<int>(false, "The agent identifier.")
            .WithName("UpdateAgent")
            .WithOpenApi();

        group.MapPost("/", AgentEndpointHandlers.CreateAgentHandlerAsync)
            .Accepts<AgentDto>(false, "The agent.")
            .WithName("CreateAgent")
            .WithOpenApi();

        group.MapDelete("/{id}", AgentEndpointHandlers.DeleteAgentHandlerAsync)
            .Accepts<int>(false, "The agent identifier.")
            .WithName("DeleteAgent")
            .WithOpenApi();
    }
}
