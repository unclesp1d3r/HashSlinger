namespace HashSlinger.Api.Services;

/// <summary>Defines a service for storing and retrieving files.</summary>
public interface IFileStorageService
{
    /// <summary>Files the exists asynchronously.</summary>
    /// <param name="uuid">The UUID.</param>
    /// <param name="bucket">The bucket.</param>
    /// <returns>True, if the file exists; false, if not.</returns>
    public Task<bool> FileExistsAsync(Guid uuid, string bucket);

    /// <summary>Gets the file asynchronously.</summary>
    /// <param name="uuid">The UUID.</param>
    /// <param name="bucket">The bucket.</param>
    /// <returns>A stream of file contents.</returns>
    public Task<Stream?> GetFileAsync(Guid uuid, string bucket);

    /// <summary>Stores the file asynchronously.</summary>
    /// <param name="uuid">The UUID.</param>
    /// <param name="bucket">The bucket.</param>
    /// <param name="fileStream">The file stream.</param>
    public Task<bool> StoreFileAsync(Guid uuid, string bucket, Stream fileStream);

    //public Task<Results<Ok, NotFound>> DeleteFileAsync(Guid uuid, string bucket);
    //public Task<Results<Ok, NotFound>> DeleteFilesAsync(Guid uuid);
}
