namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using DAL;
using Models;
using Models.Enums;
using Serilog;

/// <summary>Sent by the client to login and get the timeout setting.</summary>
public record LoginRequest(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("clientSignature")]
    string ClientSignature,
    [property: JsonPropertyName("token")] string Token
) : IHashtopolisRequest
{
    /// <inheritdoc />
    public async Task<IHashtopolisMessage> ProcessRequestAsync(Repository repository)
    {
        Agent? agent = await repository.GetAgentByTokenAsync(Token).ConfigureAwait(true);

        if (agent is null)
        {
            Log.Error("Agent not found");
            return new LoginResponse(Action, HashtopolisConstants.ErrorResponse, null, "Agent not found.");
        }

        agent.ClientSignature = ClientSignature;
        agent.LastSeenTime = DateTime.UtcNow;
        agent.LastAction = AgentActions.Login;

        await repository.UpdateAgentAsync(agent).ConfigureAwait(true);
        return new LoginResponse(Action,
            HashtopolisConstants.SuccessResponse,
            HashSlingerConfiguration.AgentTimeout);
    }
}
