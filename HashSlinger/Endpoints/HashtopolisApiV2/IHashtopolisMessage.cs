namespace HashSlinger.Api.Endpoints.HashtopolisApiV2;

/// <summary>An interface for all of the various API requests that can be submitted by the Hashtopolis client.</summary>
public interface IHashtopolisMessage { }

/// <summary>An interface for requests coming into the server from the Hashtopolis client.</summary>
public interface IHashtopolisRequest : IHashtopolisMessage
{
    /// <summary>Processes the request.</summary>
    /// <returns>The associated response object.</returns>
    public IHashtopolisMessage ProcessRequest();
}
