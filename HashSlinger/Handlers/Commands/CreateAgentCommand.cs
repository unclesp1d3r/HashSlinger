namespace HashSlinger.Api.Handlers.Commands;

using Data;
using MediatR;
using Models;

/// <summary>Command for creating an agent.</summary>
public record CreateAgentCommand(Agent Agent) : IRequest<int>;

/// <summary>Handler for creating an agent.</summary>

// ReSharper disable once UnusedType.Global
public class CreateAgentHandler : IRequestHandler<CreateAgentCommand, int>
{
    private readonly HashSlingerContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="CreateAgentHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    public CreateAgentHandler(HashSlingerContext dbContext) => _dbContext = dbContext;

    /// <summary>Handles a request</summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    public async Task<int> Handle(CreateAgentCommand request, CancellationToken cancellationToken)
    {
        //await WriteLogEventAsync(LogEntry.Information($"Creating agent {newAgent}", Issuer))
        //    .ConfigureAwait(true);
        Agent newAgent = request.Agent;
        await _dbContext.Agents.AddAsync(newAgent, cancellationToken).ConfigureAwait(true);
        return await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(true);
    }
}
