namespace HashSlinger.Api.Handlers.Queries;

using System.Text;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Shared.Models.Enums;

/// <summary>
/// Represents a query to get a Hashlist download.
/// </summary>
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
        Hashlist? hashlist = await _context.Hashlists.Include(x => x.Hashes)
            .Include(x => x.HashBinaries)
            .SingleOrDefaultAsync(x => x.Id == request.HashlistId, cancellationToken)
            .ConfigureAwait(false);

        // Verify Agent has access to Hashlist
        if (hashlist == null
            || agent.IsTrusted != hashlist.IsSecret
            || agent.AccessGroups.All(x => x.Id != hashlist.AccessGroupId))
            return Results.BadRequest("Agent does not have access to hashlist.");
        var hashes = hashlist.Hashes.Where(x => x.IsCracked == false).ToList();
        if (!hashes.Any())
            return Results.NoContent();
        switch (hashlist.Format)
        {
            case HashListFormats.TextFile:
                var sb = new StringBuilder();
                hashes.ForEach(hash =>
                {
                    sb.AppendLine(hashlist.IsSalted
                        ? $"{hash.HashValue}{hashlist.SaltSeparator}{hash.Salt}"
                        : $"{hash.HashValue}");
                });
                return Results.File(Encoding.UTF8.GetBytes(sb.ToString()), "text/plain", request.HashlistId.ToString());
            case HashListFormats.BinaryFile:
            case HashListFormats.HCCAPXFile:
                var binaryHashes = hashes.Select(x => Convert.FromHexString(x.HashValue)).ToArray();
                var data = new byte[binaryHashes.Sum(arr => arr.Length)];
                using (var stream = new MemoryStream(data))
                {
                    foreach (var bytes in binaryHashes)
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
