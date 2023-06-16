namespace HashSlinger.Api.Handlers.Queries;

using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models;
using SemanticVersioning;
using Serilog;

/// <summary>Represents a query to get the cracker binary for the specified version.</summary>
public record GetCrackerBinaryQuery(int? CurrentVersion) : IRequest<CrackerBinary?>;

/// <summary>Handles getting the cracker binary for the specified version.</summary>
public class GetCrackerBinaryHandler : IRequestHandler<GetCrackerBinaryQuery, CrackerBinary?>
{
    private readonly HashSlingerContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="GetCrackerBinaryHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    public GetCrackerBinaryHandler(HashSlingerContext dbContext) => _dbContext = dbContext;

    /// <summary>Handles a request</summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    public async Task<CrackerBinary?> Handle(
        GetCrackerBinaryQuery request,
        CancellationToken cancellationToken
    )
    {
        Log.Information("Getting cracker binary for version {version}", request.CurrentVersion);
        var satisfyingRange = new Range($">={request.CurrentVersion}");
        List<CrackerBinary> getBinaries = await _dbContext.CrackerBinaries.Include(a => a.File)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(true);

        if (getBinaries.Count == 0)
        {
            Log.Warning("No cracker binaries found.");
            return null;
        }

        IEnumerable<Version> validVersions = getBinaries.Select(b => new Version(b.Version))
            .Where(v => satisfyingRange.IsSatisfied(v));
        Version? latestVersion = satisfyingRange.MaxSatisfying(validVersions);

        CrackerBinary? crackerBinary
            = getBinaries.SingleOrDefault(b => b.Version == latestVersion?.ToString());
        Log.Information("The latest cracker binary is {version}", crackerBinary!.Version);
        return crackerBinary;
    }
}
