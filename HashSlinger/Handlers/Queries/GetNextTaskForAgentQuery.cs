namespace HashSlinger.Api.Handlers.Queries;

using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models;
using Serilog;

public record GetNextTaskForAgentQuery(string Token) : IRequest<Task?>;

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
            .FirstOrDefaultAsync(a => a.Token == request.Token, cancellationToken)
            .ConfigureAwait(true);

        Task? nextTask = agent?.Assignments.Select(a => a.Task).MaxBy(t => t.Priority);


        return nextTask;
    }
}
