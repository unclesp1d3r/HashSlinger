namespace HashSlinger.Api.Handlers.Queries;

using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

/// <summary>Represents a query to get the next task for an agent.</summary>
public record GetNextTaskForAgentProjectionQuery(int AgentId) : IRequest<GetNextTaskForAgentProjectionResponse?>;

/// <summary>Handles getting the next task for an agent.</summary>
/// <remarks>This ugly beast needs to be refined. It's a mess.</remarks>
public class GetNextTaskForAgentProjectionHandler : IRequestHandler<GetNextTaskForAgentProjectionQuery,
    GetNextTaskForAgentProjectionResponse?>
{
    private readonly HashSlingerContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="GetNextTaskForAgentProjectionHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    public GetNextTaskForAgentProjectionHandler(HashSlingerContext dbContext) => _dbContext = dbContext;

    /// <inheritdoc />
    public async Task<GetNextTaskForAgentProjectionResponse?> Handle(
        GetNextTaskForAgentProjectionQuery request,
        CancellationToken cancellationToken
    )
    {
        Log.Information("Getting next task for Agent {AgentId}", request.AgentId);

        var nextTaskId = await _dbContext.Tasks
            //.Include(x => x.Assignments)
            .Where(t => t.Assignments.Any(a => a.AgentId == request.AgentId))
            .OrderByDescending(t => t.Priority)
            .ThenBy(t => t.Keyspace)
            .AsSplitQuery()
            .Select(t => t.Id)
            .FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(true);


        return await _dbContext.Tasks.Where(t => t.Id == nextTaskId)
            .Select(t => new GetNextTaskForAgentProjectionResponse(t.Id,
                t.TaskWrapper.HashlistId,
                t.UseNewBenchmark ? "speed" : "run",
                t.CrackerBinary!.Id,
                t.Files.Select(f => f.FileName).ToList(),
                t.Keyspace,
                t.UsePreprocessor,
                t.Preprocessor != null ? null : t.Preprocessor!.Id,
                t.PreprocessorCommand,
                t.EnforcePipe,
                t.Priority))
            .AsSplitQuery()
            .FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(true);
    }
}

/// <summary>
/// Represents the response from <see cref="GetNextTaskForAgentProjectionHandler" />.
/// </summary>
public record GetNextTaskForAgentProjectionResponse(
    int TaskId,
    int HashlistId,
    string BenchType,
    int CrackerBinaryId,
    List<string> FileNames,
    ulong Keyspace,
    bool UsePreprocessor,
    int? PreprocessorId,
    string? PreprocessorCommand,
    bool EnforcePipe,
    int Priority = 0
);
