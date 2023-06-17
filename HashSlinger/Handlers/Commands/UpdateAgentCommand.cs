namespace HashSlinger.Api.Handlers.Commands;

using Data;
using MediatR;
using Models;
using Serilog;
using Task = Task;

/// <summary>Represents a command to update an agent.</summary>
public record UpdateAgentCommand(Agent Agent) : IRequest;

/// <summary>Handles updating an agent in the database.</summary>

// ReSharper disable once UnusedType.Global
public class UpdateAgentHandler : IRequestHandler<UpdateAgentCommand>
{
    private readonly HashSlingerContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="UpdateAgentHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    public UpdateAgentHandler(HashSlingerContext dbContext) => _dbContext = dbContext;

    /// <inheritdoc />
    public Task Handle(UpdateAgentCommand request, CancellationToken cancellationToken)
    {
        Log.Debug("Updating agent {Agent}", request.Agent);
        _dbContext.Agents.Update(request.Agent);
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
