namespace HashSlinger.Api.Services;

using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;

/// <summary>A <see cref="IFileStorageService" /> implementation that uses the local file system.</summary>
public class LocalFileStorageService : IFileStorageService
{
    private string _localStoragePath = HashSlingerConfiguration.LocalStoragePath;


    /// <summary>The local storage path</summary>
    public string LocalStoragePath
    {
        get => _localStoragePath;
        set
        {
            LocalFileStorageService.EnsureDirectoryExists(value);
            _localStoragePath = value;
        }
    }

    /// <inheritdoc />
    public async Task<bool> StoreFileAsync(Guid uuid, string bucket, Stream fileStream)
    {
        string filePath = Path.Combine(GetBucketPath(bucket), uuid.ToString());
        EnsureBucketExists(bucket);
        await using (FileStream stream = File.Create(filePath))
        {
            await fileStream.CopyToAsync(stream).ConfigureAwait(true);
        }

        Log.Information("Stored file {uuid} in bucket {bucket} at {filePath}", uuid, bucket, filePath);
        return await FileExistsAsync(uuid, bucket).ConfigureAwait(true);
    }


    /// <inheritdoc />
    public async Task<Stream?> GetFileAsync(Guid uuid, string bucket)
    {
        string filePath = Path.Combine(GetBucketPath(bucket), uuid.ToString());
        if (!File.Exists(filePath)) return null;
        FileStream stream = File.OpenRead(filePath);
        return stream;
    }

    /// <inheritdoc />
    public Task<bool> FileExistsAsync(Guid uuid, string bucket)
    {
        string filePath = Path.Combine(GetBucketPath(bucket), uuid.ToString());
        return Task.FromResult(File.Exists(filePath));
    }

    /// <inheritdoc />
    public async Task<Results<Ok, NotFound>> DeleteFileAsync(Guid uuid, string bucket)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<Results<Ok, NotFound>> DeleteFilesAsync(Guid uuid)
    {
        throw new NotImplementedException();
    }

    private static void EnsureDirectoryExists(string path)
    {
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
    }

    private void EnsureBucketExists(string bucket)
    {
        string bucketPath = GetBucketPath(bucket);
        LocalFileStorageService.EnsureDirectoryExists(bucketPath);
    }

    private string GetBucketPath(string bucket)
    {
        return Path.Combine(LocalStoragePath, bucket);
    }
}
