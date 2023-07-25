namespace HashSlinger.Api.Handlers.Queries;

using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shared.Models;

/// <summary>
/// Represents a query to get a file from a task.
/// </summary>
public record GetFileQuery(int TaskId, string FileName) : IRequest<File?>;

/// <summary>
/// Handles getting a file from a task.
/// </summary>
public class GetFileHandler : IRequestHandler<GetFileQuery, File?>
{
    private readonly HashSlingerContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="GetFileHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    public GetFileHandler(HashSlingerContext dbContext) => _dbContext = dbContext;


    /// <inheritdoc />
    public async Task<File?> Handle(GetFileQuery request, CancellationToken cancellationToken)
    {
        Log.Debug("Getting file {FileName} from task {TaskId}", request.FileName, request.TaskId);
        //Task? task = await _dbContext.Tasks.FindAsync(request.TaskId).ConfigureAwait(true);

        //File? file = await _dbContext.Files.Where(x => task != null && task.Files.Any(f => f.FileName == request.FileName))
        //.FirstOrDefaultAsync(x => x.FileName == request.FileName, cancellationToken)
        //.ConfigureAwait(true);

        File? file = await _dbContext.Files.FirstOrDefaultAsync(x => x.FileName == request.FileName, cancellationToken)
                                     .ConfigureAwait(true);


        Log.Information("File {FileName} from task {TaskId} found: {FileFound}",
            request.FileName,
            request.TaskId,
            file != null);


        return file;
    }
}
