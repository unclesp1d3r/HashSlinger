namespace HashSlinger.Api.Handlers.Commands;

using Data;
using MediatR;
using Models;
using Models.Enums;
using Serilog;
using Task = System.Threading.Tasks.Task;

/// <summary>Represents a command to assign a health check to all agents.</summary>
/// <seealso cref="MediatR.IRequest" />
/// <seealso cref="MediatR.IBaseRequest" />
public record AssignAllAgentsHealthCheckCommand : IRequest;

/// <summary>Creates a new health check and assigns it to all agents.</summary>
/// <remarks>This is just for testing and development.</remarks>
public class AssignAllAgentsHealthCheckHandler : IRequestHandler<AssignAllAgentsHealthCheckCommand>
{
    private readonly HashSlingerContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="AssignAllAgentsHealthCheckHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    public AssignAllAgentsHealthCheckHandler(HashSlingerContext dbContext) => _dbContext = dbContext;


    /// <inheritdoc />
    public Task Handle(AssignAllAgentsHealthCheckCommand request, CancellationToken cancellationToken)
    {
        Log.Information("Assigning HealthCheck to all Agents");


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
        else
        {
            _dbContext.HealthChecks.Update(healthCheck);
        }

        _dbContext.HealthChecks.Update(healthCheck);


        foreach (Agent? agent in _dbContext.Agents.AsEnumerable())
        {
            _dbContext.HealthCheckAgents.Add(new HealthCheckAgent
            {
                Agent = agent,
                HealthCheck = healthCheck,
                Status = HealthCheckStatus.Pending,
                Errors = new List<string>()
            });
        }


        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
