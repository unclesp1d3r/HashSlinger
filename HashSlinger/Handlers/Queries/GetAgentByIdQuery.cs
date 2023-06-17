namespace HashSlinger.Api.Handlers.Queries;

using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models;
using Serilog;

/// <summary>Represents a query to retrieve an agent by its ID</summary>
public record GetAgentByIdQuery(int Id) : IRequest<Agent?>;

/// <summary>Handles retrieving an agent by its ID</summary>

// ReSharper disable once UnusedType.Global
// ReSharper disable once UnusedMember.Global
public class GetAgentByIdHandler : IRequestHandler<GetAgentByIdQuery, Agent?>
{
    private readonly HashSlingerContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="GetAgentByIdHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    public GetAgentByIdHandler(HashSlingerContext dbContext) => _dbContext = dbContext;

    /// <summary>Handles a request</summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    public async Task<Agent?> Handle(GetAgentByIdQuery request, CancellationToken cancellationToken)
    {
        Log.Debug("Getting agent {Id}", request.Id);
        Agent? agent = await _dbContext.Agents.Include(a => a.AccessGroups)
            .Include(a => a.User)
            .Include(a => a.Chunks)
            .SingleOrDefaultAsync(a => a.Id == request.Id, cancellationToken)
            .ConfigureAwait(true);
        return agent;
    }
}
