namespace HashSlinger.Api.Handlers.Queries;

using Data;
using MediatR;
using Models;
using Models.Enums;
using Task = System.Threading.Tasks.Task;

/// <summary>Represents a query to check if there is a pending health check for an agent.</summary>
/// <seealso cref="MediatR.IBaseRequest" />
public record GetPendingHealthCheckForAgentQuery(int AgentId) : IRequest<bool>;

/// <summary>Handles checking if there is a pending health check for an agent.</summary>
public class GetPendingHealthCheckForAgentHandler : IRequestHandler<GetPendingHealthCheckForAgentQuery, bool>
{
    private readonly HashSlingerContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="GetPendingHealthCheckForAgentHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    public GetPendingHealthCheckForAgentHandler(HashSlingerContext dbContext) => _dbContext = dbContext;


    /// <inheritdoc />
    public Task<bool> Handle(GetPendingHealthCheckForAgentQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Agent>? agent = _dbContext.Agents.Where(a =>
            a.Id == request.AgentId && a.HealthCheckAgents.Count(h => h.Status == HealthCheckStatus.Pending) > 0);
        return Task.FromResult(agent.Any());
    }
}
