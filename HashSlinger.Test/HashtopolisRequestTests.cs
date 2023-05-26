namespace HashSlinger.Test;

using System.Text.Json;
using Api.Endpoints.HashtopolisApiV2;
using Api.Endpoints.HashtopolisApiV2.DTO;

public class HashtopolisRequestTests
{
    [SetUp] public void Setup() { }

    [Test]
    public void TestConnectionRequestDeserializeTest()
    {
        var jsonMessage = """
            {
                "action":"testConnection"
            }
            """;

        var hashtopolisRequest = JsonSerializer.Deserialize<HashtopolisRequest>(jsonMessage);

        Assert.That(hashtopolisRequest, Is.Not.Null);
        Assert.That(hashtopolisRequest?.Action, Is.EqualTo("testConnection"));

        Assert.Pass();
    }

    [Test]
    public void TestConnectionRequestConvertTest()
    {
        var jsonMessage = """
            {
                "action":"testConnection"
            }
            """;

        var hashtopolisRequest = JsonSerializer.Deserialize<HashtopolisRequest>(jsonMessage);

        Assert.That(hashtopolisRequest, Is.Not.Null);

        var testConnectionRequest = (TestConnectionRequest?)hashtopolisRequest?.ToHashtopolisRequest();
        Assert.That(testConnectionRequest, Is.Not.Null);
        Assert.That(testConnectionRequest, Is.TypeOf<TestConnectionRequest>());
        Assert.That(testConnectionRequest?.Action, Is.EqualTo("testConnection"));

        Assert.Pass();
    }
}
