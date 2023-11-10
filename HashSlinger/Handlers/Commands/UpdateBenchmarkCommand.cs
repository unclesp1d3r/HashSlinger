namespace HashSlinger.Api.Handlers.Commands;

using MediatR;
using Queries;
using Serilog;
using Shared.Models;

/// <summary>
/// Represents a command to update a benchmark for a task.
/// </summary>
public record UpdateBenchmarkCommand(int taskId, string agentToken, string benchmark) : IRequest;

/// <summary>
/// Handles updating a benchmark for a task.
/// </summary>
// ReSharper disable once UnusedMember.Global
public class UpdateBenchmarkCommandHandler : IRequestHandler<UpdateBenchmarkCommand>
{
    private readonly IMediator _mediator;

    /// <summary>Initializes a new instance of the <see cref="UpdateBenchmarkCommandHandler" /> class.</summary>
    /// <param name="mediator">The mediator.</param>
    public UpdateBenchmarkCommandHandler(IMediator mediator) => _mediator = mediator;

    //
    /// <inheritdoc />
    public async System.Threading.Tasks.Task Handle(UpdateBenchmarkCommand request, CancellationToken cancellationToken)
    {
        // Get Task
        Log.Debug("Getting task for agent: {agent}", request.agentToken);
        Task? task = await _mediator.Send(new GetTaskByIdQuery(request.agentToken, request.taskId), cancellationToken)
                                    .ConfigureAwait(false);
        if (task is null)
        {
            Log.Error("Task not found!");
            return;
        }

        Assignment? assignment = task.Assignments.SingleOrDefault(a => a.Agent.Token == request.agentToken);
        if (assignment is null)
        {
            Log.Error("Assignment not found!");
            return;
        }
        // Update Benchmark
        Log.Information("Updating benchmark for task {task} and agent {agent}", task.Id, request.agentToken);
        assignment.Benchmark = request.benchmark;
        await _mediator.Send(new UpdateTaskCommand(task), cancellationToken)
                       .ConfigureAwait(false);

    }
}

