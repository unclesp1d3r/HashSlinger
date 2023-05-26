namespace HashSlinger.Test;

using System.Text;
using System.Text.Json;
using Api.Endpoints.HashtopolisApiV2;
using Api.Endpoints.HashtopolisApiV2.DTO;
using Microsoft.AspNetCore.Mvc.Testing;

internal class HashtopolisApiIntegrationTests
{
    private WebApplicationFactory<Program> _factory = null!;
    private HttpClient _client = null!;

    [SetUp]
    public void Setup()
    {
        _factory = new WebApplicationFactory<Program>();
        _client = _factory.CreateClient();
    }

    [Test]
    public async Task TestConnectionTest()
    {
        var request = new HashtopolisRequest("testConnection");
        string data = JsonSerializer.Serialize(request);

        var expected = new TestConnectionResponse("testConnection", "SUCCESS");


        HttpResponseMessage response = await _client.PostAsync("/api/hashtopolis",
            new StringContent(data, Encoding.UTF8, "application/json"));
        string actualJsonString = await response.Content.ReadAsStringAsync();

        var actual = JsonSerializer.Deserialize<TestConnectionResponse>(actualJsonString);

        Assert.That(actual, Is.EqualTo(expected));
    }
}
