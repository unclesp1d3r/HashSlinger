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
    public async Task<IHashtopolisMessage?> ProcessRequestAsync(HashSlingerContext db)
    {
        RegistrationVoucher? voucher
            = await Repository.GetRegistrationVoucherAsync(db, Voucher).ConfigureAwait(true);


        if (voucher == null) return new RegisterResponse(Action, "ERROR", "Voucher not found");

        if (voucher.Expiration < DateTime.Now)
            return new RegisterResponse(Action, "ERROR", "Voucher expired");

        if (voucher.Voucher != Voucher) return null;

        var newAgent = new Agent
        {
            Name = Name,
            LastAction = AgentActions.Register,
            Token = voucher.GetRandomToken()
        };

        int result = await Repository.CreateAgentAsync(db, newAgent).ConfigureAwait(true);

        if (result == 0) return new RegisterResponse(Action, "ERROR", "Failed to create agent");

        await Repository.DeleteRegistrationVoucherAsync(db, voucher).ConfigureAwait(true);
        return new RegisterResponse(Action, "SUCCESS", newAgent.Token);
    }
}
