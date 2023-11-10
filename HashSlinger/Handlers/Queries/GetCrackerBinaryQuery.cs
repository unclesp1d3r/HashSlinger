namespace HashSlinger.Api.Handlers.Queries;

using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shared.Models;

/// <summary>Represents a query to get the cracker binary for the specified version.</summary>
public record GetCrackerBinaryQuery(int? BinaryVersionId) : IRequest<CrackerBinary?>;

/// <summary>Handles getting the cracker binary for the specified version.</summary>

// ReSharper disable once UnusedType.Global
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
    public async Task<CrackerBinary?> Handle(GetCrackerBinaryQuery request, CancellationToken cancellationToken)
    {
        Log.Information("Getting cracker binary for version {Version}", request.BinaryVersionId);
        CrackerBinary? crackerBinary = await _dbContext.CrackerBinaries.Include(a => a.File)
                                                       .SingleOrDefaultAsync(c => c.Id == request.BinaryVersionId,
                                                           cancellationToken)
                                                       .ConfigureAwait(true);

        if (crackerBinary is null)
        {
            Log.Warning("No cracker binaries found");
            return null;
        }

        Log.Information("The latest cracker binary is {Version}", crackerBinary!.Version);
        return crackerBinary;
    }
}
