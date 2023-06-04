namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using DAL;
using Models;
using Models.Enums;
using Serilog;

/// <summary>
///     This is used by the client to check if there is an update available for the client script. Type specifies
///     the type of the client.
/// </summary>
public record CheckClientVersionRequest(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("version")]
    string Version,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("token")] string Token
) : IHashtopolisRequest
{
    /// <inheritdoc />
    public async Task<IHashtopolisMessage> ProcessRequestAsync(Repository repository)
    {
        Agent? agent = await repository.GetAgentByTokenAsync(Token).ConfigureAwait(false);
        if (agent == null)
        {
            Log.Information("Agent not found");
            return new UpdateInformationResponse(Action,
                HashtopolisConstants.ErrorResponse,
                Token,
                "Agent not found.");
        }

        agent.LastAction = AgentActions.CheckClientVersion;
        agent.LastSeenTime = DateTime.UtcNow;

        int result = await repository.UpdateAgentAsync(agent).ConfigureAwait(true);
        if (result != 1) Log.Error("Failed to update agent");

        AgentBinary? clientBinary = await repository.GetAgentBinaryAsync(Type, Version).ConfigureAwait(false);

        if (clientBinary == null)
        {
            Log.Information("No client binary found for type {type}", Type);
            return new UpdateInformationResponse(Action,
                HashtopolisConstants.ErrorResponse,
                Token,
                "No client binary found for type " + Type);
        }

        if (clientBinary.Version == Version)
        {
            Log.Information("Client is up to date");
            return new CheckClientVersionResponse(Action,
                HashtopolisConstants.SuccessResponse,
                HashtopolisConstants.ClientVersionCheckCurrent,
                null,
                Token);
        }

        return new CheckClientVersionResponse(Action,
            HashtopolisConstants.SuccessResponse,
            HashtopolisConstants.ClientVersionCheckUpdateAvailable,
            clientBinary.DownloadUrl,
            Token);
    }
}
