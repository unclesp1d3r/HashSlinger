namespace HashSlinger.Api.Handlers.Queries;

using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models;

/// <summary>Represents a query to get a binary by name</summary>
public record GetBinaryByNameQuery(string Name) : IRequest<DownloadableBinary?>;

/// <summary>Handles getting a binary by name</summary>

// ReSharper disable once UnusedMember.Global
// ReSharper disable once UnusedType.Global
public class GetBinaryByNameHandler : IRequestHandler<GetBinaryByNameQuery, DownloadableBinary?>
{
    private readonly HashSlingerContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="GetBinaryByNameHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    public GetBinaryByNameHandler(HashSlingerContext dbContext) => _dbContext = dbContext;

    /// <summary>Handles a request</summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    public async Task<DownloadableBinary?> Handle(GetBinaryByNameQuery request, CancellationToken cancellationToken)
    {
        DownloadableBinary? result = await _dbContext.DownloadableBinaries.Where(b => b.Name == request.Name)
                                                     .OrderByDescending(b => b.Version)
                                                     .LastOrDefaultAsync(cancellationToken)
                                                     .ConfigureAwait(true);
        return result;
    }
}
