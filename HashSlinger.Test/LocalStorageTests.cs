namespace HashSlinger.Test;

using Api.Services;
using Serilog;

[TestFixture]
public class LocalStorageTests
{
    [SetUp]
    public void Setup()
    {
        _logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.Console().CreateLogger();
        _service = new LocalFileStorageService();
    }

    private ILogger _logger = null!;
    private LocalFileStorageService _service = null!;


    private static readonly string LocalStoragePath = Path.Combine(Path.GetTempPath(), "HashSlingerTest");
    private const string LocalStorageBucket = "test";

    [Test]
    public async Task StoreAndRetrieveFileTest()
    {
        const string testString = "Hello, world!";
        var uuid = Guid.NewGuid();

        _service.LocalStoragePath = LocalStoragePath;
        string filePath = Path.Combine(LocalStoragePath, LocalStorageBucket, uuid.ToString());
        using (var fileStream = new MemoryStream())
        {
            var writer = new StreamWriter(fileStream);
            await writer.WriteLineAsync(testString);
            await writer.FlushAsync();
            fileStream.Position = 0;

            await _service.StoreFileAsync(uuid, LocalStorageBucket, fileStream);
        }

        Assert.That(File.Exists(filePath), Is.True);

        await using (Stream? fileStream2 = await _service.GetFileAsync(uuid, LocalStorageBucket))
        {
            Assert.That(fileStream2, Is.Not.Null);
            var reader = new StreamReader(fileStream2!);
            string? contents = await reader.ReadLineAsync();
            Assert.That(contents, Is.EqualTo(testString));
        }

        File.Delete(filePath);
        Assert.That(File.Exists(filePath), Is.False);
        Assert.Pass();
    }
}
