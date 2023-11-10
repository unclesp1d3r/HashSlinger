namespace HashSlinger.Api.Handlers.Queries;

using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shared.Models;

/// <summary>Represents a query to retrieve an agent by token.</summary>
public record GetAgentByTokenQuery(string Token) : IRequest<Agent?>;

/// <summary>Handles retrieving an agent by token.</summary>

// ReSharper disable once UnusedMember.Global
// ReSharper disable once UnusedType.Global
public class GetAgentByTokenHandler : IRequestHandler<GetAgentByTokenQuery, Agent?>
{
    private readonly HashSlingerContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="GetAgentByTokenHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    public GetAgentByTokenHandler(HashSlingerContext dbContext) => _dbContext = dbContext;

    /// <summary>Handles a request</summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    public Task<Agent?> Handle(GetAgentByTokenQuery request, CancellationToken cancellationToken)
    {
        Log.Debug("Getting agent by token {Token}", request.Token);
        return _dbContext.Agents.Include(a => a.AccessGroups)
                         .SingleOrDefaultAsync(a => a.Token == request.Token, cancellationToken);
    }
}
