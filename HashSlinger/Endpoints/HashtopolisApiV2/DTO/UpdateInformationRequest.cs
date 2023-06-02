namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using DAL;
using Models;
using Models.Enums;
using Serilog;

/// <summary>Sent by the client to send information about the client operating system and the available hardware.</summary>
public record UpdateInformationRequest(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("token")] string Token,
    [property: JsonPropertyName("uid")] string Uid,
    [property: JsonPropertyName("os")] int? OperatingSystem,
    [property: JsonPropertyName("devices")]
    ICollection<string> Devices
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

        AgentOperatingSystems os = OperatingSystem is not null
            ? !Enum.IsDefined(typeof(AgentOperatingSystems), OperatingSystem.Value)
                ? AgentOperatingSystems.Unknown
                : (AgentOperatingSystems)OperatingSystem.Value
            : AgentOperatingSystems.Unknown;

        agent.OperatingSystem = os;
        agent.LastAction = AgentActions.UpdateClientInformation;
        agent.LastSeenTime = DateTime.UtcNow;
        agent.Devices = Devices;
        if (string.IsNullOrWhiteSpace(agent.Uid)) agent.CpuOnly = !agent.CheckForGpuDevices();

        agent.Uid = Uid;


        int result = await repository.UpdateAgentAsync(agent).ConfigureAwait(true);
        if (result != 1) Log.Error("Failed to update agent");

        return new UpdateInformationResponse(Action, HashtopolisConstants.SuccessResponse, Token);
    }
}
