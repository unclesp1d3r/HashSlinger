namespace HashSlinger.Api.Handlers.Queries;

using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

/// <summary>Represents a query to validating an agent token.</summary>
public record ValidateAgentTokenQuery(string Token) : IRequest<bool>;

/// <summary>Handles validating an agent token.</summary>
// ReSharper disable once UnusedMember.Global
public class ValidateAgentTokenHandler : IRequestHandler<ValidateAgentTokenQuery, bool>
{
    private readonly HashSlingerContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="ValidateAgentTokenHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    public ValidateAgentTokenHandler(HashSlingerContext dbContext) => _dbContext = dbContext;

    /// <inheritdoc />
    public Task<bool> Handle(ValidateAgentTokenQuery request, CancellationToken cancellationToken)
    {
        Log.Debug("Getting agent by token {Token}", request.Token);
        return _dbContext.Agents.AnyAsync(a => a.Token == request.Token, cancellationToken);
    }
}
