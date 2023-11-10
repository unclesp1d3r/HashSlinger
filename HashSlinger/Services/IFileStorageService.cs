namespace HashSlinger.Api.Services;

/// <summary>Defines a service for storing and retrieving files.</summary>
public interface IFileStorageService
{
    /// <summary>Files the exists asynchronously.</summary>
    /// <param name="name">The name.</param>
    /// <param name="bucket">The bucket.</param>
    /// <returns>True, if the file exists; false, if not.</returns>
    public Task<bool> FileExistsAsync(string name, string bucket);

    /// <summary>Gets the file asynchronously.</summary>
    /// <param name="name"></param>
    /// <param name="bucket"></param>
    /// <returns></returns>
    public Task<Stream?> GetFileAsync(string name, string bucket);

    /// <summary>
    /// Gets the file information asynchronous.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="bucket">The bucket.</param>
    /// <returns></returns>
    public Task<FileInfo?> GetFileInfoAsync(string name, string bucket);

    /// <summary>Stores the file asynchronously.</summary>
    /// <param name="name">The name.</param>
    /// <param name="bucket">The bucket.</param>
    /// <param name="fileStream">The file stream.</param>
    /// <returns>
    ///     <br />
    /// </returns>
    public Task<bool> StoreFileAsync(string name, string bucket, Stream fileStream);
}
