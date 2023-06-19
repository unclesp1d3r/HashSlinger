namespace HashSlinger.Api.Handlers.Queries;

using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models;
using Serilog;

/// <summary>Represents a query to get the next task for an agent.</summary>
public record GetNextTaskForAgentQuery(string Token) : IRequest<Task?>;

/// <summary>Handles getting the next task for an agent.</summary>
/// <remarks>This ugly beast needs to be refined. It's a mess.</remarks>
public class GetNextTaskForAgentHandler : IRequestHandler<GetNextTaskForAgentQuery, Task?>
{
    private readonly HashSlingerContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="GetNextTaskForAgentHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    public GetNextTaskForAgentHandler(HashSlingerContext dbContext) => _dbContext = dbContext;

    /// <inheritdoc />
    public async Task<Task?> Handle(GetNextTaskForAgentQuery request, CancellationToken cancellationToken)
    {
        Log.Information("Getting next task for Agent {Token}", request.Token);
        Agent? agent = await _dbContext.Agents.Include(a => a.Assignments)
            .ThenInclude(a => a.Task)
            .ThenInclude(t => t.TaskWrapper)
            .Include(a => a.Assignments)
            .ThenInclude(a => a.Task)
            .ThenInclude(t => t.Files)
            .Include(a => a.Assignments)
            .ThenInclude(a => a.Task)
            .ThenInclude(t => t.Preprocessor)
            .Include(a => a.Assignments)
            .ThenInclude(a => a.Task)
            .ThenInclude(t => t.CrackerBinary)
            .AsSplitQuery()
            .FirstOrDefaultAsync(a => a.Token == request.Token, cancellationToken)
            .ConfigureAwait(true);

        Task? nextTask = agent?.Assignments.Select(a => a.Task).MaxBy(t => t.Priority);


        return nextTask;
    }
}
