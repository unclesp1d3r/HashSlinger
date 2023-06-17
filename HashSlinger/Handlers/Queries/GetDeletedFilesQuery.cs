namespace HashSlinger.Api.Handlers.Queries;

using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models;

/// <summary>
///     Represents a query to retrieve all deleted files from the database.
/// </summary>
public record GetDeletedFilesQuery : IRequest<List<FileDelete>>;

/// <summary>
///     Handles retrieving all deleted files from the database.
/// </summary>
// ReSharper disable once UnusedMember.Global
public class GetDeletedFilesHandler : IRequestHandler<GetDeletedFilesQuery, List<FileDelete>>
{
    private readonly HashSlingerContext _dbContext;

    /// <summary>
    ///     Initializes a new instance of the <see cref="GetDeletedFilesHandler" /> class.
    /// </summary>
    /// <param name="dbContext">The database context.</param>
    public GetDeletedFilesHandler(HashSlingerContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public Task<List<FileDelete>> Handle(GetDeletedFilesQuery request, CancellationToken cancellationToken)
    {
        return _dbContext.FileDeletes.ToListAsync(cancellationToken);
    }
}
