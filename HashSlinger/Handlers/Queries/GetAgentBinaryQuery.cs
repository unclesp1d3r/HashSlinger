namespace HashSlinger.Api.Handlers.Queries;

using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SemanticVersioning;
using Serilog;
using Shared.Models;

/// <summary>Represents a query to retrieve the agent binary.</summary>
public record GetAgentBinaryQuery(string CurrentVersion, string Type) : IRequest<AgentBinary?>;

/// <summary>Handles retrieving the agent binary.</summary>

// ReSharper disable once UnusedMember.Global
// ReSharper disable once UnusedType.Global
public class GetAgentBinaryQueryHandler : IRequestHandler<GetAgentBinaryQuery, AgentBinary?>
{
    private readonly HashSlingerContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="GetAgentBinaryQueryHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    public GetAgentBinaryQueryHandler(HashSlingerContext dbContext) => _dbContext = dbContext;

    /// <summary>Handles a request</summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    public async Task<AgentBinary?> Handle(GetAgentBinaryQuery request, CancellationToken cancellationToken)
    {
        Log.Debug("Getting client binary for type {Type}", request.Type);
        var satisfyingRange = new Range($">={request.CurrentVersion}");
        List<AgentBinary> getBinaries = await _dbContext.AgentBinaries.Include(a => a.File)
                                                        .Where(b => b.Type == request.Type)
                                                        .ToListAsync(cancellationToken)
                                                        .ConfigureAwait(true);

        if (getBinaries.Count == 0)
        {
            Log.Warning("No binaries found for type {Type}", request.Type);
            return null;
        }

        IEnumerable<Version> validVersions = getBinaries.Select(b => new Version(b.Version))
                                                        .Where(v => satisfyingRange.IsSatisfied(v));
        Version? latestVersion = satisfyingRange.MaxSatisfying(validVersions);

        AgentBinary? clientBinary = getBinaries.SingleOrDefault(b => b.Version == latestVersion?.ToString());
        Log.Debug("The latest version for {Type} is {Version}", request.Type, clientBinary!.Version);
        return clientBinary;
    }
}
