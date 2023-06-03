namespace HashSlinger.Test;

using System.Text;
using System.Text.Json;
using Api.Data;
using Api.Endpoints.HashtopolisApiV2;
using Api.Endpoints.HashtopolisApiV2.DTO;
using Api.Models;
using Api.Models.Enums;
using Microsoft.Extensions.DependencyInjection;
using Task = System.Threading.Tasks.Task;

internal class HashtopolisApiIntegrationTests
{
    private HttpClient _client = null!;
    private MyWebApplicationFactory _factory = null!;


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

    [Test]
    public async Task BadRequestIntegrationTest()
    {
        var request = new HashtopolisRequest("badRequest");
        string data = JsonSerializer.Serialize(request);
        HashtopolisRequest expected = request with { Response = HashtopolisConstants.ErrorResponse };
        using (HttpContent requestContent = new StringContent(data, Encoding.UTF8, "application/json"))
        {
            HttpResponseMessage response = await _client.PostAsync(HashtopolisConstants.EndPointPrefix,
                requestContent);

            string actualJsonString = await response.Content.ReadAsStringAsync();

            var actual = JsonSerializer.Deserialize<HashtopolisRequest>(actualJsonString);
            Assert.That(actual, Is.EqualTo(expected));
        }

        Assert.Pass();
    }

    [Test]
    public async Task TestConnectionIntegrationTest()
    {
        var request = new TestConnectionRequest("testConnection");
        string data = JsonSerializer.Serialize(request);

        var expected = new TestConnectionResponse("testConnection", HashtopolisConstants.SuccessResponse);

        using (HttpContent requestContent = new StringContent(data, Encoding.UTF8, "application/json"))
        {
            HttpResponseMessage response = await _client.PostAsync(HashtopolisConstants.EndPointPrefix,
                requestContent);

            response.EnsureSuccessStatusCode();

            string actualJsonString = await response.Content.ReadAsStringAsync();

            var actual = JsonSerializer.Deserialize<TestConnectionResponse>(actualJsonString);

            Assert.That(actual, Is.EqualTo(expected));
        }

        Assert.Pass();
    }

    [Test]
    public async Task RegisterIntegrationTest()
    {
        var request = new RegisterRequest("register", Utilities.TestVoucher, "Test Client");
        string data = JsonSerializer.Serialize(request);

        using (HttpContent requestContent = new StringContent(data, Encoding.UTF8, "application/json"))
        {
            HttpResponseMessage response = await _client.PostAsync(HashtopolisConstants.EndPointPrefix,
                requestContent);

            response.EnsureSuccessStatusCode();

            string actualJsonString = await response.Content.ReadAsStringAsync();

            var actual = JsonSerializer.Deserialize<RegisterResponse>(actualJsonString);
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
            new List<string> { "nvidia" });
        string data = JsonSerializer.Serialize(request);

        using (HttpContent requestContent = new StringContent(data, Encoding.UTF8, "application/json"))
        {
            HttpResponseMessage response = await _client.PostAsync(HashtopolisConstants.EndPointPrefix,
                requestContent);

            response.EnsureSuccessStatusCode();

            string actualJsonString = await response.Content.ReadAsStringAsync();

            var actual = JsonSerializer.Deserialize<UpdateInformationResponse>(actualJsonString);
            Assert.That(actual, Is.Not.Null);

            Assert.That(actual!.Response, Is.EqualTo(HashtopolisConstants.SuccessResponse));
        }

        Assert.Pass();
    }


    [Test]
    public async Task LoginIntegrationTest()
    {
        var request = new LoginRequest("login", "test-client-1.0", Utilities.TestToken);
        string data = JsonSerializer.Serialize(request);

        using (HttpContent requestContent = new StringContent(data, Encoding.UTF8, "application/json"))
        {
            HttpResponseMessage response = await _client.PostAsync(HashtopolisConstants.EndPointPrefix,
                requestContent);

            response.EnsureSuccessStatusCode();

            string actualJsonString = await response.Content.ReadAsStringAsync();

            var actual = JsonSerializer.Deserialize<LoginResponse>(actualJsonString);
            Assert.That(actual, Is.Not.Null);

            Assert.That(actual!.Response, Is.EqualTo(HashtopolisConstants.SuccessResponse));
        }

        Assert.Pass();
    }
}

internal static class Utilities
{
    public const string TestVoucher = "test123456";
    public const string TestToken = "testToken";

    private static void InitializeDbForTests(HashSlingerContext db)
    {
        db.RegistrationVouchers.Add(new RegistrationVoucher
        {
            Voucher = TestVoucher, Expiration = DateTime.Now.AddDays(1)
        });
        db.Agents.Add(new Agent { Name = "Test Client", Token = TestToken });
        db.SaveChanges();
    }

    public static void ReinitializeDbForTests(HashSlingerContext db)
    {
        db.RegistrationVouchers.RemoveRange(db.RegistrationVouchers);
        db.Agents.RemoveRange(db.Agents);
        InitializeDbForTests(db);
    }
}
