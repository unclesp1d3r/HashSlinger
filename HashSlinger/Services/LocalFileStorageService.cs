namespace HashSlinger.Api.Services;

using System.Text.RegularExpressions;
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
    public Task<Stream?> GetFileAsync(string name, string bucket)
    {
        string filePath = Path.Combine(GetBucketPath(bucket), name);
        if (!File.Exists(filePath)) return Task.FromResult<Stream?>(null);
        FileStream stream = File.OpenRead(filePath);
        return Task.FromResult<Stream?>(stream);
    }

    /// <inheritdoc />
    public async Task<bool> StoreFileAsync(string name, string bucket, Stream fileStream)
    {
        string filePath = Path.Combine(GetBucketPath(bucket), SanitizePath(name));
        EnsureBucketExists(bucket);
        await using (FileStream stream = File.Create(filePath))
        {
            await fileStream.CopyToAsync(stream).ConfigureAwait(true);
        }

        Log.Information("Stored file {name} in bucket {bucket} at {filePath}", name, bucket, filePath);
        return await FileExistsAsync(name, bucket).ConfigureAwait(true);
    }


    /// <inheritdoc />
    public Task<bool> FileExistsAsync(string name, string bucket)
    {
        string filePath = Path.Combine(GetBucketPath(bucket), SanitizePath(name));
        return Task.FromResult(File.Exists(filePath));
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
        return Path.Combine(LocalStoragePath, SanitizePath(bucket));
    }

    private string SanitizePath(string path)
    {
        string regexSearch = new string(Path.GetInvalidFileNameChars())
                             + new string(Path.GetInvalidPathChars());
        var r = new Regex($"[{Regex.Escape(regexSearch)}]");
        return r.Replace(path, "_");
    }
}
