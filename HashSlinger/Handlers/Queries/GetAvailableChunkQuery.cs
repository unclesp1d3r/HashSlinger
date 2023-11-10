namespace HashSlinger.Api.Handlers.Queries;

using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Shared.Models.Enums;

public record GetAvailableChunkQuery(int TaskId, int AgentId) : IRequest<Chunk?>;

public class GetAvailableChunkHandler : IRequestHandler<GetAvailableChunkQuery, Chunk?>
{
    private readonly HashSlingerContext _context;
    public GetAvailableChunkHandler(HashSlingerContext context) => _context = context;

    /// <inheritdoc />
    public Task<Chunk?> Handle(GetAvailableChunkQuery request, CancellationToken cancellationToken)
    {
        // Find chunks for this task.
        IQueryable<Chunk> orderedChunks = _context.Chunks.OrderBy(x => x.Skip).Where(x => x.TaskId == request.TaskId);

        // Find uncracked chunks for this task.
        IQueryable<Chunk> uncrackedChunks = orderedChunks.Where(x => x.State != ChunkState.Cracked)
                                                         .Where(x => x.Progress < 100.00 || x.Progress == null);

        // Find chunks that are not assigned to an agent or have been aborted or timed out.
        return uncrackedChunks.FirstOrDefaultAsync(x => x.AgentId == request.AgentId
                                                        || x.State == ChunkState.Aborted
                                                        || x.State == ChunkState.StatusAbortedRuntime
                                                        || x.DispatchTime
                                                        < DateTime.UtcNow.AddSeconds(-HashSlingerConfiguration.ChunkTimeout),
            cancellationToken);
    }
}
