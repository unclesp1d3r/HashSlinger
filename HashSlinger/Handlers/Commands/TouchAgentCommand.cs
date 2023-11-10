namespace HashSlinger.Api.Handlers.Commands;

using System.Net;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shared.Models.Enums;

/// <summary>Represents a command to update the last seen time and IP address of an agent.</summary>
/// <seealso cref="MediatR.IRequest" />
/// <seealso cref="MediatR.IBaseRequest" />
public record TouchAgentCommand(string Token, AgentActions LastAction) : IRequest;

/// <summary>Handles updating the last seen time and IP address of an agent.</summary>
// ReSharper disable once UnusedMember.Global
public class TouchAgentHandler : IRequestHandler<TouchAgentCommand>
{
    private readonly HashSlingerContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>Initializes a new instance of the <see cref="TouchAgentHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    /// <param name="httpContextAccessor">The HTTP context accessor.</param>
    public TouchAgentHandler(HashSlingerContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
    }

    /// <inheritdoc />
    public Task Handle(TouchAgentCommand request, CancellationToken cancellationToken)
    {
        IPAddress? clientIp = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress;

        Log.Information("Agent {Token} touched from {ClientIp} for action {LastAction}",
            request.Token,
            clientIp,
            request.LastAction);

        return _dbContext.Agents.Where(x => x.Token == request.Token)
                         .ForEachAsync(x =>
                             {
                                 x.LastSeenTime = DateTime.UtcNow;
                                 x.LastSeenIpAddress = clientIp;
                                 x.LastAction = request.LastAction;
                             },
                             cancellationToken);
    }
}
