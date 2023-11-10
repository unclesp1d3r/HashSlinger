namespace HashSlinger.Api.Handlers.Commands;

using Data;
using MediatR;
using Serilog;
using Shared.Models;
using Task = Task;

/// <summary>
/// Represents a command to update a chunk.
/// </summary>
public record UpdateChunkCommand(Chunk Chunk) : IRequest;

/// <summary>
/// Handles command to update a chunk.
/// </summary>
public class UpdateChunkCommandHandler : IRequestHandler<UpdateChunkCommand>
{
    private readonly HashSlingerContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="UpdateChunkCommandHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    public UpdateChunkCommandHandler(HashSlingerContext dbContext) => _dbContext = dbContext;

    /// <inheritdoc />
    public Task Handle(UpdateChunkCommand request, CancellationToken cancellationToken)
    {
        Log.Debug<Chunk>("Updating chunk {Chunk}", request.Chunk);
        _dbContext.Chunks.Update(request.Chunk);
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
