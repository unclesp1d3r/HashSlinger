namespace HashSlinger.Test;

using System.Net.Http.Headers;
using Api.Data;
using Api.Endpoints.HashtopolisApiV2;
using Microsoft.Extensions.DependencyInjection;

[TestFixture]
internal class FileEndpointIntegrationTests
{
    [SetUp]
    public void Setup()
    {
        _factory = new MyWebApplicationFactory();
        _client = _factory.CreateClient();

        using IServiceScope scope = _factory.Services.CreateScope();
        IServiceProvider scopedServices = scope.ServiceProvider;
        var db = scopedServices.GetRequiredService<HashSlingerContext>();
        db.Database.EnsureCreated();
        Utilities.ReinitializeDbForTests(db);
    }

    [TearDown]
    public void TearDown()
    {
        using IServiceScope scope = _factory.Services.CreateScope();
        IServiceProvider scopedServices = scope.ServiceProvider;
        var db = scopedServices.GetRequiredService<HashSlingerContext>();
        db.Database.EnsureDeleted();

        _client.Dispose();
        _factory.Dispose();
    }

    private HttpClient _client = null!;
    private MyWebApplicationFactory _factory = null!;

    [Test]
    public async Task FileUploadDownloadIntegrationTest()
    {
        const string bucket = "test_bucket";
        var fileId = new Guid();
        byte[] file = await File.ReadAllBytesAsync(Path.Combine("SupportFiles", "test_file.txt"));
        var fileContent = new ByteArrayContent(file);
        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("text/plain");

        using (HttpContent requestContent = new MultipartFormDataContent
                   { { fileContent, "file", "test_file.txt" } })
        {
            HttpResponseMessage response = await _client.PostAsync(
                $"{HashtopolisConstants.UploadEndPointPrefix}/{bucket}/{fileId}",
                requestContent);

            response.EnsureSuccessStatusCode();
        }

        using (HttpResponseMessage response = await _client.GetAsync(
                   $"{HashtopolisConstants.DownloadEndPointPrefix}/{bucket}/{fileId}"))
        {
            response.EnsureSuccessStatusCode();

            byte[] actual = await response.Content.ReadAsByteArrayAsync();

            Assert.That(actual, Is.EqualTo(file));
        }

        Assert.Pass();
    }
}
