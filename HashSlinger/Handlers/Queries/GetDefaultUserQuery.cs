namespace HashSlinger.Api.Handlers.Queries;

using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shared.Models;

/// <summary>Represents a query to retrieve the default user.</summary>
public record GetDefaultUserQuery : IRequest<User>;

/// <summary>Handles retrieving the default user.</summary>

// ReSharper disable once UnusedType.Global
public record GetDefaultUserHandler : IRequestHandler<GetDefaultUserQuery, User?>
{
    private readonly HashSlingerContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="GetDefaultUserHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    public GetDefaultUserHandler(HashSlingerContext dbContext) => _dbContext = dbContext;

    /// <summary>Handles the specified request.</summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The first user in the system, or null.<br /></returns>
    public Task<User?> Handle(GetDefaultUserQuery request, CancellationToken cancellationToken)
    {
        Log.Debug("Getting default user");
        return _dbContext.Users.OrderBy(u => u.RegisteredSince).FirstOrDefaultAsync(cancellationToken);
    }
}
