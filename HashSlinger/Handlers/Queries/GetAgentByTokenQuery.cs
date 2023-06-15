namespace HashSlinger.Api.Handlers.Queries;

using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models;
using Serilog;

/// <summary>Represents a query to retrieve an agent by token.</summary>
public record GetAgentByTokenQuery : IRequest<Agent?>
{
    /// <summary>Gets or sets the token.</summary>
    /// <value>The token.</value>
    public string Token { get; set; } = null!;
}

/// <summary>Handles retrieving an agent by token.</summary>
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
        Log.Debug("Getting agent by token {token}", request.Token);
        return _dbContext.Agents.SingleOrDefaultAsync(a => a.Token == request.Token, cancellationToken);
    }
}
