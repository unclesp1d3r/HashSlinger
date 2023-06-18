namespace HashSlinger.Api.Handlers.Queries;

using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enums;
using Serilog;

/// <summary>
/// Represents a query to get the HealthChecks for an Agent.
/// </summary>
/// <seealso cref="MediatR.IBaseRequest" />
public record GetHealthChecksForAgentQuery(int AgentId) : IRequest<HealthCheck?>;

/// <summary>
/// Handles getting the HealthChecks for an Agent.
/// </summary>
public class GetHealthChecksForAgentHandler : IRequestHandler<GetHealthChecksForAgentQuery, HealthCheck?>
{
    private readonly HashSlingerContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="GetHealthChecksForAgentHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    public GetHealthChecksForAgentHandler(HashSlingerContext dbContext) => _dbContext = dbContext;


    /// <inheritdoc />
    public async Task<HealthCheck?> Handle(GetHealthChecksForAgentQuery request, CancellationToken cancellationToken)
    {
        Log.Information("Getting HealthChecks for Agent {AgentId}", request.AgentId);
        Agent? agent = await _dbContext.Agents.Where(a => a.Id == request.AgentId)
            .Include(a => a.HealthCheckAgents)
            .ThenInclude(h => h.HealthCheck)
            .ThenInclude(hc => hc.CrackerBinary)
            .SingleOrDefaultAsync(cancellationToken)
            .ConfigureAwait(true);
        if (agent is null) return null;

        IEnumerable<HealthCheckAgent> pendingHealthChecks
            = agent.HealthCheckAgents.Where(h => h.Status == HealthCheckStatus.Pending);
        IEnumerable<HealthCheckAgent> healthCheckAgents = pendingHealthChecks.ToList();
        Log.Information("Agent {AgentId} has {pendingHealthChecks} HealthChecks", request.AgentId, healthCheckAgents);
        HealthCheck? result = !healthCheckAgents.Any() ? null : healthCheckAgents.MinBy(h => h.Id)?.HealthCheck;
        if (result is not null)
            Log.Information("Agent {AgentId} has {@TestHashes} as the next HealthCheck", request.AgentId, result.TestHashes);
        return result;
    }
}
