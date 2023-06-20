namespace HashSlinger.Api.Endpoints.UserApiV1;

using Handlers.Commands;
using MediatR;
using Shared.Generated;
using Shared.Models;

/// <summary>Contains the version 1 API for user interface functionality.</summary>
public static class UserApiEndPoints
{
    /// <summary>
    /// The API prefix
    /// </summary>
    public const string ApiPrefix = "/api/v1";

    /// <summary>Maps the user API endpoints.</summary>
    /// <param name="routes">The routes.</param>
    public static void MapUserApiEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapAgentEndpoints();
        routes.MapRegistrationVoucherEndpoints();
        routes.MapUtilityEndpoints();
        routes.MapTaskEndpoints();
    }

    /// <summary>Maps the utility endpoints.</summary>
    /// <param name="routes">The routes.</param>
    public static void MapUtilityEndpoints(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder group = routes.MapGroup($"{ApiPrefix}/Utils").WithTags("Utils");
        // Mostly for testing. This is not part of the final API.
        group.MapPost("/initial-setup", void (IMediator mediator) => mediator.Send(new PerformInitialSetupCommand()))
            .WithOpenApi();

        // Mostly for testing. This is not part of the final API.
        group.MapPost("/create-health-check",
                void (IMediator mediator) => mediator.Send(new AssignAllAgentsHealthCheckCommand()))
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
            .Accepts<int>(false, "application/json")
            .WithOpenApi();

        group.MapPut("/{id:int}", AgentEndpointHandlers.UpdateAgentHandlerAsync)
            .Accepts<int>(false, "application/json")
            .WithName("UpdateAgent")
            .WithOpenApi();

        group.MapPost("/", AgentEndpointHandlers.CreateAgentHandlerAsync)
            .Accepts<AgentDto>(false, "application/json")
            .WithName("CreateAgent")
            .WithOpenApi();

        group.MapDelete("/{id}", AgentEndpointHandlers.DeleteAgentHandlerAsync)
            .Accepts<int>(false, "application/json")
            .WithName("DeleteAgent")
            .WithOpenApi();
    }


    /// <summary>Maps the registration voucher endpoints.</summary>
    /// <param name="routes">The routes.</param>
    internal static void MapRegistrationVoucherEndpoints(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder? group = routes.MapGroup($"{ApiPrefix}/RegistrationVoucher").WithTags(nameof(RegistrationVoucher));

        group.MapGet("/", RegistrationVoucherEndpointHandlers.GetAllRegistrationVouchersHandlerAsync)
            .WithName("GetAllRegistrationVouchers")
            .Produces<List<RegistrationVoucherDto>>(StatusCodes.Status200OK)
            .WithOpenApi();

        group.MapGet("/{id:int}", RegistrationVoucherEndpointHandlers.GetRegistrationVoucherByIdHandlerAsync)
            .WithName("GetRegistrationVoucherById")
            .Produces<RegistrationVoucherDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

        group.MapPut("/{id:int}", RegistrationVoucherEndpointHandlers.UpdateRegistrationVoucherHandlerAsync)
            .Accepts<RegistrationVoucherDto>(false, "application/json")
            .WithName("UpdateRegistrationVoucher")
            .WithOpenApi();

        group.MapPost("/", RegistrationVoucherEndpointHandlers.CreateRegistrationVoucherHandlerAsync)
            .Accepts<RegistrationVoucherDto>(false, "application/json")
            .WithName("CreateRegistrationVoucher")
            .WithOpenApi();

        group.MapDelete("/{id:int}", RegistrationVoucherEndpointHandlers.DeleteRegistrationVoucherHandlerAsync)
            .WithName("DeleteRegistrationVoucher")
            .WithOpenApi();
    }

    /// <summary>
    /// Maps the task endpoints.
    /// </summary>
    /// <param name="routes">The routes.</param>
    public static void MapTaskEndpoints(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder? group = routes.MapGroup($"{ApiPrefix}/Task").WithTags(nameof(Task));

        group.MapGet("/", TaskEndpointHandlers.GetAllTasksHandlerAsync)
            .Produces<List<TaskDto>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("GetAllTasks")
            .WithOpenApi();

        group.MapGet("/{id:int}", TaskEndpointHandlers.GetTaskByIdHandlerAsync)
            .Produces<TaskDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Accepts<int>(false, "application/json")
            .WithName("GetTaskById")
            .WithOpenApi();

        group.MapPut("/{id:int}", TaskEndpointHandlers.UpdateTaskHandlerAsync)
            .Produces<TaskDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Accepts<int>(false, "application/json")
            .WithName("UpdateTask")
            .WithOpenApi();

        group.MapPost("/", TaskEndpointHandlers.CreateTaskHandlerAsync)
            .Produces<TaskDto>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status404NotFound)
            .Accepts<TaskDto>(false, "application/json")
            .WithName("CreateTask")
            .WithOpenApi();

        group.MapDelete("/{id:int}", TaskEndpointHandlers.DeleteTaskHandlerAsync)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Accepts<int>(false, "application/json")
            .WithName("DeleteTask")
            .WithOpenApi();
    }
}
