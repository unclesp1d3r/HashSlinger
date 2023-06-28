namespace HashSlinger.Api.Handlers.Queries;

using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

/// <summary>Represents a query for a hashlist by Id.</summary>
public record GetHashlistByIdQuery(int RequestHashlistId) : IRequest<Hashlist?>;

/// <summary>Handles getting a hashlist by Id.</summary>
public class GetHashlistByIdHandler : IRequestHandler<GetHashlistByIdQuery, Hashlist?>
{
    private readonly HashSlingerContext _context;

    /// <summary>Initializes a new instance of the <see cref="GetHashlistByIdHandler" /> class.</summary>
    /// <param name="context">The context.</param>
    public GetHashlistByIdHandler(HashSlingerContext context) => _context = context;

    /// <inheritdoc />
    public Task<Hashlist?> Handle(GetHashlistByIdQuery request, CancellationToken cancellationToken)
    {
        return _context.Hashlists.Include(x => x.AccessGroup)
            .FirstOrDefaultAsync(x => x.Id == request.RequestHashlistId, cancellationToken);
    }
}
