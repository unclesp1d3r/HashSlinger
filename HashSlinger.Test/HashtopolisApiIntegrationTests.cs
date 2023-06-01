namespace HashSlinger.Test;

using System.Text;
using System.Text.Json;
using Api.Data;
using Api.Endpoints.HashtopolisApiV2;
using Api.Endpoints.HashtopolisApiV2.DTO;
using Api.Models;
using Api.Models.Enums;
using Microsoft.Extensions.DependencyInjection;
using Task = Task;

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
        HashtopolisRequest expected = request with { Response = "ERROR" };

        HttpResponseMessage response = await _client.PostAsync("/api/hashtopolis",
            new StringContent(data, Encoding.UTF8, "application/json"));


        string actualJsonString = await response.Content.ReadAsStringAsync();
        var actual = JsonSerializer.Deserialize<HashtopolisRequest>(actualJsonString);
        Assert.That(actual, Is.EqualTo(expected));

        Assert.Pass();
    }

    [Test]
    public async Task TestConnectionIntegrationTest()
    {
        var request = new TestConnectionRequest("testConnection");
        string data = JsonSerializer.Serialize(request);

        var expected = new TestConnectionResponse("testConnection", "SUCCESS");

        HttpResponseMessage response = await _client.PostAsync("/api/hashtopolis",
            new StringContent(data, Encoding.UTF8, "application/json"));

        response.EnsureSuccessStatusCode();

        string actualJsonString = await response.Content.ReadAsStringAsync();

        var actual = JsonSerializer.Deserialize<TestConnectionResponse>(actualJsonString);

        Assert.That(actual, Is.EqualTo(expected));

        Assert.Pass();
    }

    [Test]
    public async Task RegisterIntegrationTest()
    {
        const string testVoucher = "test123456";

        var request = new RegisterRequest("register", testVoucher, "Test Client");
        string data = JsonSerializer.Serialize(request);


        HttpResponseMessage response = await _client.PostAsync("/api/hashtopolis",
            new StringContent(data, Encoding.UTF8, "application/json"));

        response.EnsureSuccessStatusCode();

        string actualJsonString = await response.Content.ReadAsStringAsync();

        var actual = JsonSerializer.Deserialize<RegisterResponse>(actualJsonString);
        Assert.That(actual, Is.Not.Null);

        Assert.That(actual!.Response, Is.EqualTo("SUCCESS"));

        Assert.Pass();
    }

    [Test]
    public async Task UpdateInformationIntegrationTest()
    {
        const string testVoucher = "test123456";

        var request = new UpdateInformationRequest("updateInformation",
            testVoucher,
            "Test Client",
            (int)AgentOperatingSystems.Windows,
            new List<string> { "nvidia" });
        string data = JsonSerializer.Serialize(request);


        HttpResponseMessage response = await _client.PostAsync("/api/hashtopolis",
            new StringContent(data, Encoding.UTF8, "application/json"));

        response.EnsureSuccessStatusCode();

        string actualJsonString = await response.Content.ReadAsStringAsync();

        var actual = JsonSerializer.Deserialize<UpdateInformationResponse>(actualJsonString);
        Assert.That(actual, Is.Not.Null);

        Assert.That(actual!.Response, Is.EqualTo("SUCCESS"));

        Assert.Pass();
    }
}

internal static class Utilities
{
    public static void InitializeDbForTests(HashSlingerContext db)
    {
        //db.Messages.AddRange(GetSeedingMessages());
        db.RegistrationVouchers.Add(new RegistrationVoucher
        {
            Voucher = "test123456",
            Expiration = DateTime.Now.AddDays(1)
        });
        db.Agents.Add(new Agent
        {
            Name = "Test Client",
            Token = "test123456"
        });
        db.SaveChanges();
    }

    public static void ReinitializeDbForTests(HashSlingerContext db)
    {
        db.RegistrationVouchers.RemoveRange(db.RegistrationVouchers);
        InitializeDbForTests(db);
    }
}
