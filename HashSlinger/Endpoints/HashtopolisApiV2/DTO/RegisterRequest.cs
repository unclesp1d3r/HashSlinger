namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
    public async Task<IHashtopolisMessage> ProcessRequestAsync(HashSlingerContext db)
    {
        RegistrationVoucher? voucher = await db.RegistrationVouchers
            .FirstOrDefaultAsync(v => v.Voucher == Voucher)
            .ConfigureAwait(true);


        if (voucher == null) return new RegisterResponse(Action, "ERROR", "Voucher not found");

        if (voucher.Expiration < DateTime.Now)
            return new RegisterResponse(Action, "ERROR", "Voucher expired");

        if (voucher.Voucher == Voucher)
        {
            var newAgent = new Agent
            {
                Name = Name,
                LastAction = AgentActions.Register,
                Token = voucher.GetRandomToken()
            };

            //bool success = await repository.AddAgentAsync(newAgent).ConfigureAwait(true);
            EntityEntry<Agent> result = await db.Agents.AddAsync(newAgent).ConfigureAwait(true);
            await db.SaveChangesAsync().ConfigureAwait(true);

            return new RegisterResponse(Action, "SUCCESS", voucher.GetRandomToken());
        }

        return null!;
    }
}
