namespace HashSlinger.Api.Handlers.Commands;

using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Task = Task;

/// <summary>
/// Represents the command to update all file records from files on disk.
/// </summary>
public record UpdateFileRecordsCommand : IRequest;

/// <summary>
/// Handles updating all file records from files on disk.
/// </summary>
public class UpdateFileRecordsHandler : IRequestHandler<UpdateFileRecordsCommand>
{
    private readonly HashSlingerContext _dbContext;
    private readonly IMediator _mediator;

    /// <summary>Initializes a new instance of the <see cref="UpdateFileRecordsHandler" /> class.</summary>
    /// <param name="mediator">The mediator.</param>
    /// <param name="dbContext">The database context.</param>
    public UpdateFileRecordsHandler(IMediator mediator, HashSlingerContext dbContext)
    {
        _mediator = mediator;
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task Handle(UpdateFileRecordsCommand request, CancellationToken cancellationToken)
    {
        List<File> files = await _dbContext.Files.ToListAsync(cancellationToken).ConfigureAwait(true);
        foreach (File file in files)
        {
            await _mediator.Send(new UpdateFileRecordCommand(file.Id), cancellationToken).ConfigureAwait(true);
        }
    }
}
