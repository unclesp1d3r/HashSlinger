namespace HashSlinger.Api.Handlers.Commands;

using System.Collections.Generic;
using Data;
using MediatR;
using Models;
using Models.Enums;
using Serilog;
using Task = Task;

public record AssignAllAgentsHealthCheckCommand : IRequest;

public class AssignAllAgentsHealthCheckHandler : IRequestHandler<AssignAllAgentsHealthCheckCommand>
{
    private readonly HashSlingerContext _dbContext;
    public AssignAllAgentsHealthCheckHandler(HashSlingerContext dbContext) => _dbContext = dbContext;


    /// <inheritdoc />
    public async Task Handle(AssignAllAgentsHealthCheckCommand request, CancellationToken cancellationToken)
    {
        Log.Information("Assigning HealthCheck to all Agents");


        Agent agent = _dbContext.Agents.OrderBy(a => a.Id).FirstOrDefault()!;
        CrackerBinary? hashcat = _dbContext.CrackerBinaries.FirstOrDefault(x => x.Name == "hashcat")!;
        HashType? hashType = _dbContext.HashTypes.SingleOrDefault(x => x.HashcatId == 0)!;
        var healthCheck = new HealthCheck
        {
            Id = 1,
            AttackCmd = $"--hash-type {hashType.HashcatId} #HL# -a 3 -1 ?l?u?d ?1?1?1?1?1",
            ExpectedCracks = 2,
            HashType = hashType,
            Status = HealthCheckStatus.Pending,
            CheckType = 0,
            CrackerBinary = hashcat,
            TestHashes = new List<string>
            {
                "9f650d4ef70eead895e7a03ce0f83e88",
                "24a7bdfd14bca7f9d14154c0800a833d"
            },
            HashListAlias = "#HL#"
        };
        if (_dbContext.HealthChecks.Count() != 1)
        {
            _dbContext.HealthChecks.RemoveRange(_dbContext.HealthChecks);
            _dbContext.HealthChecks.Add(healthCheck);
        }

        _dbContext.HealthChecks.Update(healthCheck);

        await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

        var healthCheckAssignment = new HealthCheckAgent
        {
            Agent = agent,
            HealthCheck = healthCheck,
            Status = HealthCheckStatus.Pending
        };
        healthCheck.HealthCheckAgents.Add(healthCheckAssignment);
        _dbContext.HealthChecks.Update(healthCheck);
        await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(true);
    }
}
