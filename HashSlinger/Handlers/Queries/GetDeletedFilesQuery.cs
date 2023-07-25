namespace HashSlinger.Api.Handlers.Queries;

using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>Represents a query to retrieve all deleted files from the database.</summary>
public record GetDeletedFileNamesQuery : IRequest<string[]>;

/// <summary>Handles retrieving all deleted files from the database.</summary>
// ReSharper disable once UnusedMember.Global
public class GetDeletedFileNamesHandler : IRequestHandler<GetDeletedFileNamesQuery, string[]>
{
    private readonly HashSlingerContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="GetDeletedFileNamesHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    public GetDeletedFileNamesHandler(HashSlingerContext dbContext) => _dbContext = dbContext;

    /// <inheritdoc />
    public Task<string[]> Handle(GetDeletedFileNamesQuery request, CancellationToken cancellationToken)
    {
        return _dbContext.FileDeletes.Select(x => x.FileName).ToArrayAsync(cancellationToken);
    }
}
