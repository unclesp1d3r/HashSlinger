namespace HashSlinger.Api.Handlers.Commands;

using HashSlinger.Api.Data;
using MediatR;
using Services;

/// <summary>
/// Represents the command to update a file record from a file on disk.
/// </summary>
public record UpdateFileRecordCommand(int FileId) : IRequest;

/// <summary>
/// Handles updating a file record from a file on disk.
/// </summary>
public class UpdateFileRecordHandler : IRequestHandler<UpdateFileRecordCommand>
{
    private readonly HashSlingerContext _dbContext;
    private readonly IFileStorageService _storageService;
    /// <summary>Initializes a new instance of the <see cref="UpdateFileRecordHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    public UpdateFileRecordHandler(HashSlingerContext dbContext, IFileStorageService storageService)
    {
        _dbContext = dbContext;
        _storageService = storageService;
    }

    /// <inheritdoc />
    public async Task Handle(UpdateFileRecordCommand request, CancellationToken cancellationToken)
    {
        Shared.Models.File? fileRecord = _dbContext.Files.FirstOrDefault(x => x.Id == request.FileId) ?? throw new InvalidOperationException("FileRecord is null");

        var fileName = fileRecord.FileName;
        var file = await _storageService.GetFileInfoAsync(fileName, "files").ConfigureAwait(true);
        if (file is null) throw new InvalidOperationException("File is null");
        if (!file.Exists) throw new InvalidOperationException("File does not exist");

        fileRecord.Size = file.Length;
        fileRecord.LineCount = File.ReadLines(file.FullName).Count();

        await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(true);
    }
}
