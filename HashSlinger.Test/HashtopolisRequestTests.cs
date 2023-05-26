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
        var jsonMessage = @"{
                ""action"":""testConnection""
                }";

        var hashtopolisRequest = JsonSerializer.Deserialize<HashtopolisRequest>(jsonMessage);

        Assert.IsNotNull(hashtopolisRequest);
        Assert.AreEqual("testConnection", hashtopolisRequest?.Action);

        Assert.Pass();
    }

    [Test]
    public void TestConnectionRequestConvertTest()
    {
        var jsonMessage = @"{
                ""action"":""testConnection""
                }";

        var hashtopolisRequest = JsonSerializer.Deserialize<HashtopolisRequest>(jsonMessage);

        Assert.IsNotNull(hashtopolisRequest);

        var testConnectionRequest = (TestConnectionRequest?)hashtopolisRequest?.ToHashtopolisRequest();
        Assert.IsNotNull(testConnectionRequest);
        Assert.IsInstanceOf(typeof(TestConnectionRequest), testConnectionRequest);
        Assert.AreEqual("testConnection", testConnectionRequest?.Action);

        Assert.Pass();
    }
}
