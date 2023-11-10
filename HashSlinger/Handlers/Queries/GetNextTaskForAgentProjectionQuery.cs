namespace HashSlinger.Api.Handlers.Queries;

using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shared.Models;

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

        var nextTaskId = await _dbContext.Tasks.Where(t => t.Assignments.Any(a => a.AgentId == request.AgentId))
                                         .OrderByDescending(t => t.Priority)
                                         .ThenBy(t => t.Keyspace)
                                         .AsSplitQuery()
                                         .Select(t => t.Id)
                                         .FirstOrDefaultAsync(cancellationToken)
                                         .ConfigureAwait(true);

        Log.Information("Next task ID: {TaskId}", nextTaskId);

        if (nextTaskId == 0)
        {
            Log.Information("No tasks found for Agent {AgentId}", request.AgentId);
            Task? nextUnassignedTask = await _dbContext.Tasks.Include(t => t.Assignments)
                                                       .Where(t => t.MaxAgents == 0 || t.Assignments.Count != t.MaxAgents)
                                                       .OrderByDescending(t => t.Priority)
                                                       .ThenBy(t => t.Keyspace)
                                                       .AsSplitQuery()
                                                       .FirstOrDefaultAsync(cancellationToken)
                                                       .ConfigureAwait(true);
            if (nextUnassignedTask is null || nextUnassignedTask.Id == 0)
            {
                Log.Information("No unassigned tasks found for Agent {AgentId}", request.AgentId);
                return null;
            }

            nextTaskId = nextUnassignedTask.Id;
            Log.Information("Assigning unassigned task {TaskId} to Agent {AgentId}", nextTaskId, request.AgentId);
            nextUnassignedTask.Assignments.Add(new Assignment
            {
                AgentId = request.AgentId
            });
            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(true);
        }


        return await _dbContext.Tasks.Where(t => t.Id == nextTaskId)
                               .Select(t => new GetNextTaskForAgentProjectionResponse(t.Id,
                                   t.AttackCommand,
                                   t.TaskWrapper.HashlistId,
                                   t.UseNewBenchmark ? "speed" : "run",
                                   t.CrackerBinary!.Id,
                                   t.Files.Select(f => f.FileName).ToList(),
                                   t.Keyspace,
                                   t.UsePreprocessor,
                                   t.Preprocessor != null ? null : t.Preprocessor!.Id,
                                   t.PreprocessorCommand,
                                   t.EnforcePipe,
                                   t.TaskWrapper.Hashlist.HashType.IsSlowHash,
                                   t.Priority,
                                   $" --hash-type={t.TaskWrapper.Hashlist.HashType.HashcatId} {t.Assignments.Single(a => a.Agent.Id == request.AgentId).Agent.CommandParameters}"))
                               .FirstOrDefaultAsync(cancellationToken)
                               .ConfigureAwait(true);
    }
}

/// <summary>Represents the response from <see cref="GetNextTaskForAgentProjectionHandler" />.</summary>
public record GetNextTaskForAgentProjectionResponse(
    int TaskId,
    string AttackCommand,
    int HashlistId,
    string BenchType,
    int CrackerId,
    List<string> Files,
    ulong Keyspace,
    bool UsePreprocessor,
    int? PreprocessorId,
    string? PreprocessorCommand,
    bool EnforcePipe,
    bool? SlowHash,
    int Priority = 0,
    string? CommandParameters = null
);
