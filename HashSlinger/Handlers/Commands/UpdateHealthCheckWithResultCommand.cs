namespace HashSlinger.Api.Handlers.Commands;

using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enums;
using Task = Task;

/// <summary>
/// Represents the command to update the health check agent with the results of the health check.
/// </summary>
public record UpdateHealthCheckWithResultCommand(
    string AgentToken,
    int NumberCracked,
    ulong Start,
    ulong End,
    int NumberGpus,
    ICollection<string> Errors,
    int CheckId
) : IRequest;

/// <summary>
/// Handles updating the health check agent with the results of the health check.
/// </summary>
public class UpdateHealthCheckWithResultHandler : IRequestHandler<UpdateHealthCheckWithResultCommand>
{
    private readonly HashSlingerContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="UpdateHealthCheckWithResultHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    public UpdateHealthCheckWithResultHandler(HashSlingerContext dbContext) => _dbContext = dbContext;

    /// <inheritdoc />
    public async Task Handle(UpdateHealthCheckWithResultCommand request, CancellationToken cancellationToken)
    {
        Agent? agent = await _dbContext.Agents.Include(x => x.HealthCheckAgents)
            .ThenInclude(h => h.HealthCheck)
            .FirstOrDefaultAsync(x => x.Token == request.AgentToken, cancellationToken)
            .ConfigureAwait(false);
        HealthCheckAgent? healthCheckAgent
            = agent?.HealthCheckAgents.FirstOrDefault(x => x.HealthCheck.Id == request.CheckId);

        if (healthCheckAgent is null)
            throw new InvalidOperationException("HealthCheckAgent is null");
        healthCheckAgent.Cracked = request.NumberCracked;
        healthCheckAgent.Start = request.Start;
        healthCheckAgent.End = request.End;
        healthCheckAgent.NumGpus = request.NumberGpus;
        healthCheckAgent.Errors = request.Errors.ToList();
        healthCheckAgent.Status = request.Errors.Count != 0 ? HealthCheckStatus.Failed : HealthCheckStatus.Completed;

        await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }
}
