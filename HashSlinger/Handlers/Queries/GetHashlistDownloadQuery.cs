namespace HashSlinger.Api.Handlers.Queries;

using System.Text;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Shared.Models.Enums;

/// <summary>Represents a query to get a Hashlist download.</summary>
public record GetHashlistDownloadQuery(int HashlistId, string AgentToken) : IRequest<IResult>;

/// <summary>Handles requests for Hashlist downloads.</summary>
public class GetHashlistDownloadHandler : IRequestHandler<GetHashlistDownloadQuery, IResult>
{
    private readonly HashSlingerContext _context;

    /// <summary>Initializes a new instance of the <see cref="GetHashlistDownloadHandler" /> class.</summary>
    /// <param name="context">The context.</param>
    public GetHashlistDownloadHandler(HashSlingerContext context) => _context = context;

    /// <inheritdoc />
    public async Task<IResult> Handle(GetHashlistDownloadQuery request, CancellationToken cancellationToken)
    {
        Agent? agent = await _context.Agents.Include(x => x.AccessGroups)
                                     .FirstOrDefaultAsync(x => x.Token == request.AgentToken, cancellationToken)
                                     .ConfigureAwait(false);

        if (agent == null) return Results.Unauthorized();
        Hashlist? hashlist = await _context.Hashlists.Where(x => agent.IsTrusted == x.IsSecret)
                                           .Where(x => agent.AccessGroups.Select(a => a.Id).Contains(x.AccessGroupId))
                                           .SingleOrDefaultAsync(cancellationToken)
                                           .ConfigureAwait(true);


        // Verify Agent has access to Hashlist
        if (hashlist is null)
            return Results.BadRequest("Agent does not have access to hashlist.");

        switch (hashlist.Format)
        {
            case HashListFormats.TextFile:
                IQueryable<Hash> hashes = _context.Hashes.Where(x => x.HashlistId == hashlist.Id)
                                                  .Where(x => x.IsCracked == false);

                var sb = new StringBuilder();
                foreach (var hash in hashes.Select(x => hashlist.IsSalted
                                                            ? $"{x.HashValue}{hashlist.SaltSeparator}{x.Salt}"
                                                            : $"{x.HashValue}"))
                {
                    sb.AppendLine(hash);
                }

                return sb.Length == 0
                           ? Results.NoContent()
                           : Results.File(Encoding.UTF8.GetBytes(sb.ToString()),
                               "text/plain",
                               request.HashlistId.ToString());

            case HashListFormats.BinaryFile:
            case HashListFormats.HCCAPXFile:
                IQueryable<byte[]> binHashes = _context.BinaryHashes.Where(x => x.HashlistId == hashlist.Id)
                                                       .Where(x => x.IsCracked == false)
                                                       .Select(x => x.HashBytes);
                var data = new byte[binHashes.Sum(arr => arr.Length)];
                using (var stream = new MemoryStream(data))
                {
                    foreach (var bytes in binHashes)
                    {
                        stream.Write(bytes, 0, bytes.Length);
                    }
                }

                return Results.File(data, "application/octet-stream", request.HashlistId.ToString());
            default:
                throw new ArgumentOutOfRangeException(nameof(request));
        }
    }
}
