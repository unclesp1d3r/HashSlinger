namespace HashSlinger.Test;

using Api.Services;
using Serilog;

[TestFixture]
public class LocalStorageTests
{
    [SetUp]
    public void Setup()
    {
        new LoggerConfiguration().MinimumLevel.Debug().WriteTo.Console().CreateLogger();
        _service = new LocalFileStorageService();
    }

    private LocalFileStorageService _service = null!;


    private static readonly string LocalStoragePath = Path.Combine(Path.GetTempPath(), "HashSlingerTest");
    private const string LocalStorageBucket = "test";

    [Test]
    public async Task StoreAndRetrieveFileTest()
    {
        const string testString = "Hello, world!";
        var name = Guid.NewGuid().ToString();

        _service.LocalStoragePath = LocalStoragePath;
        var filePath = Path.Combine(LocalStoragePath, LocalStorageBucket, name);
        using (var fileStream = new MemoryStream())
        {
            var writer = new StreamWriter(fileStream);
            await writer.WriteLineAsync(testString);
            await writer.FlushAsync();
            fileStream.Position = 0;

            await _service.StoreFileAsync(name, LocalStorageBucket, fileStream);
        }

        Assert.That(File.Exists(filePath), Is.True);

        await using (Stream? fileStream2 = await _service.GetFileAsync(name, LocalStorageBucket))
        {
            Assert.That(fileStream2, Is.Not.Null);
            var reader = new StreamReader(fileStream2!);
            var contents = await reader.ReadLineAsync();
            Assert.That(contents, Is.EqualTo(testString));
        }

        File.Delete(filePath);
        Assert.That(File.Exists(filePath), Is.False);
        Assert.Pass();
    }
}
