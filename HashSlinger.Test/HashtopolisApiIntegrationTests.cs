namespace HashSlinger.Test;

using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;
using Api.Data;
using Api.Endpoints.HashtopolisApiV2;
using Api.Endpoints.HashtopolisApiV2.DTO;
using Api.Models.Enums;
using Microsoft.Extensions.DependencyInjection;

[TestFixture, SuppressMessage("ReSharper", "StringLiteralTypo")]
internal class HashtopolisApiIntegrationTests
{
    [SetUp]
    public void Setup()
    {
        _factory = new MyWebApplicationFactory();
        _client = _factory.CreateClient();

        using IServiceScope scope = _factory.Services.CreateScope();
        IServiceProvider scopedServices = scope.ServiceProvider;
        HashSlingerContext db = scopedServices.GetRequiredService<HashSlingerContext>();
        db.Database.EnsureCreated();
        Utilities.ReinitializeDbForTests(db);
    }

    [TearDown]
    public void TearDown()
    {
        using IServiceScope scope = _factory.Services.CreateScope();
        IServiceProvider scopedServices = scope.ServiceProvider;
        HashSlingerContext db = scopedServices.GetRequiredService<HashSlingerContext>();
        db.Database.EnsureDeleted();

        _client.Dispose();
        _factory.Dispose();
    }

    private HttpClient _client = null!;
    private MyWebApplicationFactory _factory = null!;

    [Test]
    public async Task BadRequestIntegrationTest()
    {
        var request = new HashtopolisRequest("badRequest");
        var data = JsonSerializer.Serialize(request);
        HashtopolisRequest expected = request with { Response = HashtopolisConstants.ErrorResponse };
        using (HttpContent requestContent = new StringContent(data, Encoding.UTF8, "application/json"))
        {
            HttpResponseMessage response = await _client.PostAsync(HashtopolisConstants.EndPointPrefix, requestContent);

            var actualJsonString = await response.Content.ReadAsStringAsync();

            HashtopolisRequest? actual = JsonSerializer.Deserialize<HashtopolisRequest>(actualJsonString);
            Assert.That(actual, Is.EqualTo(expected));
        }

        Assert.Pass();
    }

    [Test]
    public async Task TestConnectionIntegrationTest()
    {
        var request = new TestConnectionRequest("testConnection");
        var data = JsonSerializer.Serialize(request);

        var expected = new TestConnectionResponse("testConnection", HashtopolisConstants.SuccessResponse);

        using (HttpContent requestContent = new StringContent(data, Encoding.UTF8, "application/json"))
        {
            HttpResponseMessage response = await _client.PostAsync(HashtopolisConstants.EndPointPrefix, requestContent);

            response.EnsureSuccessStatusCode();

            var actualJsonString = await response.Content.ReadAsStringAsync();

            TestConnectionResponse? actual = JsonSerializer.Deserialize<TestConnectionResponse>(actualJsonString);

            Assert.That(actual, Is.EqualTo(expected));
        }

        Assert.Pass();
    }

    [Test]
    public async Task RegisterIntegrationTest()
    {
        var request = new RegisterRequest("register", Utilities.TestVoucher, "Test Client");
        var data = JsonSerializer.Serialize(request);

        using (HttpContent requestContent = new StringContent(data, Encoding.UTF8, "application/json"))
        {
            HttpResponseMessage response = await _client.PostAsync(HashtopolisConstants.EndPointPrefix, requestContent);

            response.EnsureSuccessStatusCode();

            var actualJsonString = await response.Content.ReadAsStringAsync();

            RegisterResponse? actual = JsonSerializer.Deserialize<RegisterResponse>(actualJsonString);
            Assert.That(actual, Is.Not.Null);

            Assert.That(actual!.Response, Is.EqualTo(HashtopolisConstants.SuccessResponse));
        }

        Assert.Pass();
    }

    [Test]
    public async Task UpdateInformationIntegrationTest()
    {
        var request = new UpdateInformationRequest("updateInformation",
            Utilities.TestToken,
            "Test Client",
            (int)AgentOperatingSystems.Windows,
            new List<string> { "nvidia" },
            null);
        var data = JsonSerializer.Serialize(request);

        using (HttpContent requestContent = new StringContent(data, Encoding.UTF8, "application/json"))
        {
            HttpResponseMessage response = await _client.PostAsync(HashtopolisConstants.EndPointPrefix, requestContent);

            response.EnsureSuccessStatusCode();

            var actualJsonString = await response.Content.ReadAsStringAsync();

            UpdateInformationResponse? actual = JsonSerializer.Deserialize<UpdateInformationResponse>(actualJsonString);
            Assert.That(actual, Is.Not.Null);

            Assert.That(actual!.Response, Is.EqualTo(HashtopolisConstants.SuccessResponse));
        }

        Assert.Pass();
    }


    [Test]
    public async Task LoginIntegrationTest()
    {
        var request = new LoginRequest("login", "test-client-1.0", Utilities.TestToken);
        var data = JsonSerializer.Serialize(request);

        using (HttpContent requestContent = new StringContent(data, Encoding.UTF8, "application/json"))
        {
            HttpResponseMessage response = await _client.PostAsync(HashtopolisConstants.EndPointPrefix, requestContent);

            response.EnsureSuccessStatusCode();

            var actualJsonString = await response.Content.ReadAsStringAsync();

            LoginResponse? actual = JsonSerializer.Deserialize<LoginResponse>(actualJsonString);
            Assert.That(actual, Is.Not.Null);

            Assert.That(actual!.Response, Is.EqualTo(HashtopolisConstants.SuccessResponse));
        }

        Assert.Pass();
    }

    [Test]
    public async Task CheckClientVersionCurrentIntegrationTest()
    {
        var request = new CheckClientVersionRequest("checkClientVersion", "1.0.1", "python", Utilities.TestToken);
        var data = JsonSerializer.Serialize(request);

        using (HttpContent requestContent = new StringContent(data, Encoding.UTF8, "application/json"))
        {
            HttpResponseMessage response = await _client.PostAsync(HashtopolisConstants.EndPointPrefix, requestContent);

            response.EnsureSuccessStatusCode();

            var actualJsonString = await response.Content.ReadAsStringAsync();

            CheckClientVersionResponse? actual = JsonSerializer.Deserialize<CheckClientVersionResponse>(actualJsonString);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual!.Response, Is.EqualTo(HashtopolisConstants.SuccessResponse));
                Assert.That(actual.Version, Is.EqualTo("OK"));
            });
        }

        Assert.Pass();
    }

    [Test]
    public async Task CheckClientVersionNewIntegrationTest()
    {
        var request = new CheckClientVersionRequest("checkClientVersion", "1.0.0", "python", Utilities.TestToken);
        var data = JsonSerializer.Serialize(request);

        using (HttpContent requestContent = new StringContent(data, Encoding.UTF8, "application/json"))
        {
            HttpResponseMessage response = await _client.PostAsync(HashtopolisConstants.EndPointPrefix, requestContent);

            response.EnsureSuccessStatusCode();

            var actualJsonString = await response.Content.ReadAsStringAsync();

            CheckClientVersionResponse? actual = JsonSerializer.Deserialize<CheckClientVersionResponse>(actualJsonString);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual!.Response, Is.EqualTo(HashtopolisConstants.SuccessResponse));
                Assert.That(actual.Version, Is.EqualTo("NEW"));
            });
        }

        Assert.Pass();
    }

    [Test]
    public async Task GetFileStatusIntegrationTest()
    {
        var request = new GetFileStatusRequest("getFileStatus", Utilities.TestToken);
        var data = JsonSerializer.Serialize(request);

        using (HttpContent requestContent = new StringContent(data, Encoding.UTF8, "application/json"))
        {
            HttpResponseMessage response = await _client.PostAsync(HashtopolisConstants.EndPointPrefix, requestContent);

            response.EnsureSuccessStatusCode();

            var actualJsonString = await response.Content.ReadAsStringAsync();

            GetFileStatusResponse? actual = JsonSerializer.Deserialize<GetFileStatusResponse>(actualJsonString);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual!.Response, Is.EqualTo(HashtopolisConstants.SuccessResponse));
                Assert.That(actual.FileNames.Count, Is.EqualTo(1));
            });
        }

        Assert.Pass();
    }
}
