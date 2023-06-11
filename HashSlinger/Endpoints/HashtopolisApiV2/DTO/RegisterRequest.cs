namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using DAL;
using Mapster;
using Models;
using Models.Enums;
using Serilog;

/// <summary>Sent by the client when registering a new client to the server</summary>
public record RegisterRequest(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("voucher")]
    string Voucher,
    [property: JsonPropertyName("name")] string Name
) : IHashtopolisRequest
{
    /// <inheritdoc />
    public async Task<IHashtopolisMessage> ProcessRequestAsync(Repository repository)
    {
        RegistrationVoucher? voucher
            = await repository.GetRegistrationVoucherAsync(Voucher).ConfigureAwait(true);

        if (voucher == null)
        {
            Log.Error("Voucher not found");
            return this.Adapt<RegisterResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Voucher not found."
            };
        }

        if (voucher.Expiration.HasValue && voucher.Expiration < DateTime.Now)
        {
            Log.Error("Voucher expired");
            return new RegisterResponse(Action,
                HashtopolisConstants.ErrorResponse,
                string.Empty,
                "Voucher expired.");
        }

        if (voucher.Voucher != Voucher)
        {
            Log.Error("Voucher does not match");
            return new RegisterResponse(Action,
                HashtopolisConstants.ErrorResponse,
                string.Empty,
                "Voucher does not match.");
        }

        User? user = await repository.GetDefaultUserAsync().ConfigureAwait(true);

        var newAgent = new Agent
        {
            Name = Name,
            LastAction = AgentActions.Register,
            LastSeenTime = DateTime.UtcNow,
            Token = voucher.GetRandomToken(),
            User = user
        };
        if (voucher.AccessGroup != null) newAgent.AccessGroups.Add(voucher.AccessGroup);


        int result = await repository.CreateAgentAsync(newAgent).ConfigureAwait(true);

        if (result == 0)
        {
            Log.Error("Failed to create agent");
            return new RegisterResponse(Action, "ERROR", string.Empty, "Failed to create agent");
        }

        await repository.DeleteRegistrationVoucherAsync(voucher).ConfigureAwait(true);
        Log.Debug("Created agent {AgentName} with token {AgentToken}", newAgent.Name, newAgent.Token);
        return new RegisterResponse(Action, HashtopolisConstants.SuccessResponse, newAgent.Token);
    }
}
