namespace HashSlinger.Api.Endpoints.UserApiV1;

using Handlers.Commands;
using MediatR;
using Shared.Generated;
using Shared.Models;

/// <summary>Contains the version 1 API for user interface functionality.</summary>
public static class UserApiEndPoints
{
    /// <summary>The API prefix</summary>
    public const string ApiPrefix = "/api/v1";

    /// <summary>Maps the agent binary endpoints.</summary>
    /// <param name="routes">The routes.</param>
    /// <returns></returns>
    public static void MapAgentBinaryEndpoints(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder group = routes.MapGroup("/AgentBinary").WithTags(nameof(AgentBinary));

        group.MapGet("/", AgentBinariesEndpointHandlers.GetAllAgentBinariesHandlerAsync)
             .WithName("GetAllAgentBinaries")
             .Produces<List<AgentBinaryDto>>()
             .Produces(StatusCodes.Status404NotFound)
             .WithOpenApi();

        group.MapGet("/{id:int}", AgentBinariesEndpointHandlers.GetAgentBinaryByIdHandlerAsync)
             .WithName("GetAgentBinaryById")
             .Produces<AgentBinaryDto>()
             .Produces(StatusCodes.Status404NotFound)
             .WithOpenApi();

        group.MapPut("/{id:int}", AgentBinariesEndpointHandlers.UpdateAgentBinaryHandlerAsync)
             .WithName("UpdateAgentBinary")
             .Produces(StatusCodes.Status200OK)
             .Produces(StatusCodes.Status404NotFound)
             .Accepts<AgentBinaryDto>(false, "application/json")
             .WithOpenApi();

        group.MapPost("/", AgentBinariesEndpointHandlers.CreateAgentBinaryHandlerAsync)
             .WithName("CreateAgentBinary")
             .Produces<AgentBinaryDto>(StatusCodes.Status201Created)
             .Produces(StatusCodes.Status404NotFound)
             .Accepts<AgentBinaryDto>(false, "application/json")
             .WithOpenApi();

        group.MapDelete("/{id:int}", AgentBinariesEndpointHandlers.DeleteAgentBinaryHandlerAsync)
             .WithName("DeleteAgentBinary")
             .Produces(StatusCodes.Status200OK)
             .Produces(StatusCodes.Status404NotFound)
             .WithOpenApi();
    }

    /// <summary>Maps the cracker binary endpoints.</summary>
    /// <param name="routes">The routes.</param>
    /// <returns></returns>
    public static void MapCrackerBinaryEndpoints(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder group = routes.MapGroup("/CrackerBinary").WithTags(nameof(CrackerBinary));

        group.MapGet("/", CrackerBinariesEndpointHandler.GetAllCrackerBinariesHandlerAsync)
             .WithName("GetAllCrackerBinaries")
             .Produces<List<CrackerBinaryDto>>()
             .Produces(StatusCodes.Status404NotFound)
             .WithOpenApi();

        group.MapGet("/{id:int}", CrackerBinariesEndpointHandler.GetCrackerBinaryByIdHandlerAsync)
             .WithName("GetCrackerBinaryById")
             .Produces<CrackerBinaryDto>()
             .Produces(StatusCodes.Status404NotFound)
             .WithOpenApi();

        group.MapPut("/{id:int}", CrackerBinariesEndpointHandler.UpdateCrackerBinaryHandlerAsync)
             .WithName("UpdateCrackerBinary")
             .Produces(StatusCodes.Status200OK)
             .Produces(StatusCodes.Status404NotFound)
             .Accepts<CrackerBinaryDto>(false, "application/json")
             .WithOpenApi();

        group.MapPost("/", CrackerBinariesEndpointHandler.CreateCrackerBinaryHandlerAsync)
             .WithName("CreateCrackerBinary")
             .Produces<CrackerBinaryDto>(StatusCodes.Status201Created)
             .Produces(StatusCodes.Status404NotFound)
             .Accepts<CrackerBinaryDto>(false, "application/json")
             .WithOpenApi();

        group.MapDelete("/{id:int}", CrackerBinariesEndpointHandler.DeleteCrackerBinaryHandlerAsync)
             .WithName("DeleteCrackerBinary")
             .Produces(StatusCodes.Status200OK)
             .Produces(StatusCodes.Status404NotFound)
             .WithOpenApi();
    }

    /// <summary>Maps the hashlist endpoints.</summary>
    /// <param name="routes">The routes.</param>
    /// <returns></returns>
    public static void MapHashlistEndpoints(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder group = routes.MapGroup("/Hashlist").WithTags(nameof(Hashlist));

        group.MapGet("/", HashlistEndpointHandlers.GetAllHashlistsHandlerAsync)
             .WithName("GetAllHashlists")
             .Produces<List<HashlistDto>>()
             .Produces(StatusCodes.Status404NotFound)
             .WithOpenApi();

        group.MapGet("/{id:int}", HashlistEndpointHandlers.GetHashlistByIdHandlerAsync)
             .WithName("GetHashlistById")
             .Produces<HashlistDto>()
             .Produces(StatusCodes.Status404NotFound)
             .WithOpenApi();

        group.MapPut("/{id:int}", HashlistEndpointHandlers.UpdateHashlistHandlerAsync)
             .WithName("UpdateHashlist")
             .Produces<HashlistDto>()
             .Produces(StatusCodes.Status404NotFound)
             .Accepts<HashlistDto>(false, "application/json")
             .WithOpenApi();

        group.MapPost("/", HashlistEndpointHandlers.CreateHashlistHandlerAsync)
             .WithName("CreateHashlist")
             .Produces<HashlistDto>(StatusCodes.Status201Created)
             .Produces(StatusCodes.Status404NotFound)
             .Accepts<HashlistDto>(false, "application/json")
             .WithOpenApi();

        group.MapDelete("/{id:int}", HashlistEndpointHandlers.DeleteHashlistHandlerAsync)
             .WithName("DeleteHashlist")
             .Produces(StatusCodes.Status200OK)
             .Produces(StatusCodes.Status404NotFound)
             .WithOpenApi();
    }

    /// <summary>Maps the task endpoints.</summary>
    /// <param name="routes">The routes.</param>
    public static void MapTaskEndpoints(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder group = routes.MapGroup("/Task").WithTags(nameof(Task));

        group.MapGet("/", TaskEndpointHandlers.GetAllTasksHandlerAsync)
             .Produces<List<TaskDto>>()
             .Produces(StatusCodes.Status404NotFound)
             .WithName("GetAllTasks")
             .WithOpenApi();

        group.MapGet("/{id:int}", TaskEndpointHandlers.GetTaskByIdHandlerAsync)
             .Produces<TaskDto>()
             .Produces(StatusCodes.Status404NotFound)
             .WithName("GetTaskById")
             .WithOpenApi();

        group.MapPut("/{id:int}", TaskEndpointHandlers.UpdateTaskHandlerAsync)
             .Produces(StatusCodes.Status200OK)
             .Produces(StatusCodes.Status404NotFound)
             .Accepts<TaskDto>(false, "application/json")
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
             .WithName("DeleteTask")
             .WithOpenApi();
    }

    /// <summary>Maps the user API endpoints.</summary>
    /// <param name="routes">The routes.</param>
    public static void MapUserApiEndpoints(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder group = routes.MapGroup($"{ApiPrefix}");
        group.MapAgentEndpoints();
        group.MapRegistrationVoucherEndpoints();
        group.MapUtilityEndpoints();
        group.MapTaskEndpoints();
        group.MapHashlistEndpoints();
        group.MapAgentBinaryEndpoints();
        group.MapCrackerBinaryEndpoints();
        group.MapFileEndpoints();
    }

    /// <summary>Maps the utility endpoints.</summary>
    /// <param name="routes">The routes.</param>
    public static void MapUtilityEndpoints(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder group = routes.MapGroup("/Utils").WithTags("Utils");
        // Mostly for testing. This is not part of the final API.
        group.MapPost("/initial-setup", void (IMediator mediator) => mediator.Send(new PerformInitialSetupCommand()))
             .WithOpenApi();

        // Mostly for testing. This is not part of the final API.
        group.MapPost("/create-health-check",
                 void (IMediator mediator) => mediator.Send(new AssignAllAgentsHealthCheckCommand()))
             .WithOpenApi();

        group.MapPost("/update-file/{id:int}",
                 (int id, IMediator mediator) => mediator.Send(new UpdateFileRecordCommand(id)))
             .WithOpenApi();

        group.MapPost("/update-files", (IMediator mediator) => mediator.Send(new UpdateFileRecordsCommand())).WithOpenApi();
    }

    /// <summary>Maps the agent endpoints.</summary>
    /// <param name="routes">The routes.</param>
    internal static void MapAgentEndpoints(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder group = routes.MapGroup("/Agent").WithTags(nameof(Agent));

        group.MapGet("/", AgentEndpointHandlers.GetAllAgentsHandlerAsync)
             .WithName("GetAllAgents")
             .Produces<List<AgentDto>>()
             .Produces(StatusCodes.Status404NotFound)
             .WithOpenApi();

        group.MapGet("/{id:int}", AgentEndpointHandlers.GetAgentByIdHandlerAsync)
             .WithName("GetAgentById")
             .Produces<AgentDto>()
             .Produces(StatusCodes.Status404NotFound)
             .WithOpenApi();

        group.MapPut("/{id:int}", AgentEndpointHandlers.UpdateAgentHandlerAsync)
             .Produces(StatusCodes.Status200OK)
             .Produces(StatusCodes.Status404NotFound)
             .Accepts<AgentDto>(false, "application/json")
             .WithName("UpdateAgent")
             .WithOpenApi();

        group.MapPost("/", AgentEndpointHandlers.CreateAgentHandlerAsync)
             .Accepts<AgentDto>(false, "application/json")
             .Produces<AgentDto>(StatusCodes.Status201Created)
             .Produces(StatusCodes.Status404NotFound)
             .Accepts<AgentDto>(false, "application/json")
             .WithName("CreateAgent")
             .WithOpenApi();

        group.MapDelete("/{id}", AgentEndpointHandlers.DeleteAgentHandlerAsync)
             .Accepts<int>(false, "application/json")
             .Produces(StatusCodes.Status200OK)
             .Produces(StatusCodes.Status404NotFound)
             .WithName("DeleteAgent")
             .WithOpenApi();
    }


    /// <summary>Maps the registration voucher endpoints.</summary>
    /// <param name="routes">The routes.</param>
    internal static void MapRegistrationVoucherEndpoints(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder group = routes.MapGroup("/RegistrationVoucher").WithTags(nameof(RegistrationVoucher));

        group.MapGet("/", RegistrationVoucherEndpointHandlers.GetAllRegistrationVouchersHandlerAsync)
             .WithName("GetAllRegistrationVouchers")
             .Produces<List<RegistrationVoucherDto>>()
             .Produces(StatusCodes.Status404NotFound)
             .WithOpenApi();

        group.MapGet("/{id:int}", RegistrationVoucherEndpointHandlers.GetRegistrationVoucherByIdHandlerAsync)
             .WithName("GetRegistrationVoucherById")
             .Produces<RegistrationVoucherDto>()
             .Produces(StatusCodes.Status404NotFound)
             .WithOpenApi();

        group.MapPut("/{id:int}", RegistrationVoucherEndpointHandlers.UpdateRegistrationVoucherHandlerAsync)
             .Accepts<RegistrationVoucherDto>(false, "application/json")
             .WithName("UpdateRegistrationVoucher")
             .Produces(StatusCodes.Status200OK)
             .Produces(StatusCodes.Status404NotFound)
             .Accepts<RegistrationVoucherDto>(false, "application/json")
             .WithOpenApi();

        group.MapPost("/", RegistrationVoucherEndpointHandlers.CreateRegistrationVoucherHandlerAsync)
             .Accepts<RegistrationVoucherDto>(false, "application/json")
             .WithName("CreateRegistrationVoucher")
             .Produces<RegistrationVoucherDto>(StatusCodes.Status201Created)
             .Produces(StatusCodes.Status404NotFound)
             .Accepts<RegistrationVoucherDto>(false, "application/json")
             .WithOpenApi();

        group.MapDelete("/{id:int}", RegistrationVoucherEndpointHandlers.DeleteRegistrationVoucherHandlerAsync)
             .WithName("DeleteRegistrationVoucher")
             .Produces(StatusCodes.Status200OK)
             .Produces(StatusCodes.Status404NotFound)
             .WithOpenApi();
    }

    /// <summary>Maps the file endpoints.</summary>
    public static void MapFileEndpoints(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder group = routes.MapGroup("/File").WithTags(nameof(File));

        group.MapGet("/", FileEndpointHandlers.GetAllFilesHandlerAsync)
             .WithName("GetAllFiles")
             .Produces<List<FileDto>>()
             .Produces(StatusCodes.Status404NotFound)
             .WithOpenApi();

        group.MapGet("/{id:int}", FileEndpointHandlers.GetFileByIdHandlerAsync)
             .WithName("GetFileById")
             .Produces<FileDto>()
             .Produces(StatusCodes.Status404NotFound)
             .WithOpenApi();

        group.MapPut("/{id:int}", FileEndpointHandlers.UpdateFileHandlerAsync)
             .WithName("UpdateFile")
             .Accepts<FileDto>(false, "application/json")
             .Produces(StatusCodes.Status200OK)
             .Produces(StatusCodes.Status404NotFound)
             .Accepts<FileDto>(false, "application/json")
             .WithOpenApi();

        group.MapPost("/", FileEndpointHandlers.CreateFileHandlerAsync)
             .WithName("CreateFile")
             .Accepts<FileDto>(false, "application/json")
             .Produces<FileDto>(StatusCodes.Status201Created)
             .Produces(StatusCodes.Status404NotFound)
             .Accepts<FileDto>(false, "application/json")
             .WithOpenApi();

        group.MapDelete("/{id:int}", FileEndpointHandlers.DeleteFileHandlerAsync)
             .WithName("DeleteFile")
             .Produces(StatusCodes.Status200OK)
             .Produces(StatusCodes.Status404NotFound)
             .WithOpenApi();
    }
}
