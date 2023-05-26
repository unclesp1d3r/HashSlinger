namespace HashSlinger.Test;

using System.Text.Json;
using Api.Endpoints.HashtopolisApiV2;
using Api.Endpoints.HashtopolisApiV2.DTO;

public class HashtopolisRequestTests
{
    [SetUp] public void Setup() { }

    /// <summary>
    /// Tests that a bad request is still deserialized correctly
    /// </summary>
    /// <remarks>It should still deserialize, but all of the fields will be null.</remarks>
    [Test]
    public void BadRequestDeserializeTest()
    {
        var jsonMessage = """
            {
            "bad":"request"
            }
            """;

        var hashtopolisRequest = JsonSerializer.Deserialize<HashtopolisRequest>(jsonMessage);
        Assert.That(hashtopolisRequest, Is.Not.Null);

        Assert.Pass();
    }

    /// <summary>
    /// Tests that a valid testConnection request is deserialized correctly
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Tests to ensure that a bad request is not converted to a HashtopolisRequest
    /// </summary>
    [Test]
    public void BadRequestConvertTest()
    {
        var jsonMessage = """
            {
                "action":"doesntWork"
            }
            """;

        var hashtopolisRequest = JsonSerializer.Deserialize<HashtopolisRequest>(jsonMessage);
        IHashtopolisRequest? testConnectionRequest = hashtopolisRequest?.ToHashtopolisRequest();
        Assert.That(testConnectionRequest, Is.Null);
        Assert.Pass();
    }

    /// <summary>
    /// Tests that a valid testConnection request is converted to a TestConnectionRequest
    /// </summary>
    /// <returns></returns>
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
