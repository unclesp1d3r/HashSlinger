namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using DAL;
using Data;
using Models;
using Models.Enums;

/// <summary>Sent by the client when registering a new client to the server</summary>
public record RegisterRequest(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("voucher")]
    string Voucher,
    [property: JsonPropertyName("name")] string Name
) : IHashtopolisRequest
{
    /// <inheritdoc />
    public async Task<IHashtopolisMessage> ProcessRequestAsync(HashSlingerContext db, ILogger logger)
    {
        RegistrationVoucher? voucher
            = await Repository.GetRegistrationVoucherAsync(db, Voucher).ConfigureAwait(true);


        if (voucher == null)
        {
            logger.LogInformation("Voucher not found");
            return new RegisterResponse(Action, "ERROR", "Voucher not found");
        }

        if (voucher.Expiration < DateTime.Now)
        {
            logger.LogInformation("Voucher expired");
            return new RegisterResponse(Action, "ERROR", "Voucher expired");
        }

        if (voucher.Voucher != Voucher)
        {
            logger.LogError("Voucher does not match");
            return new RegisterResponse(Action, "ERROR", "Internal error.");
        }

        var newAgent = new Agent
        {
            Name = Name,
            LastAction = AgentActions.Register,
            Token = voucher.GetRandomToken()
        };

        int result = await Repository.CreateAgentAsync(db, newAgent).ConfigureAwait(true);

        if (result == 0)
        {
            logger.LogError("Failed to create agent");
            return new RegisterResponse(Action, "ERROR", "Failed to create agent");
        }

        await Repository.DeleteRegistrationVoucherAsync(db, voucher).ConfigureAwait(true);
        logger.LogDebug("Created agent {AgentName} with token {AgentToken}", newAgent.Name, newAgent.Token);
        return new RegisterResponse(Action, "SUCCESS", newAgent.Token);
    }
}
