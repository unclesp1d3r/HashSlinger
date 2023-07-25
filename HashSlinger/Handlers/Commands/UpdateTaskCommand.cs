namespace HashSlinger.Api.Handlers.Commands;

using Data;
using MediatR;
using Serilog;
using Task = System.Threading.Tasks.Task;

/// <summary>Represents a command to update an task.</summary>
public record UpdateTaskCommand(Shared.Models.Task Task) : IRequest;

/// <summary>Handles updating an task in the database.</summary>
public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand>
{
    private readonly HashSlingerContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="UpdateTaskHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    public UpdateTaskHandler(HashSlingerContext dbContext) => _dbContext = dbContext;

    /// <inheritdoc />
    public Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        Log.Debug<Shared.Models.Task>("Updating task {Task}", request.Task);
        _dbContext.Tasks.Update(request.Task);
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
