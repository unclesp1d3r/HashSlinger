namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using DAL;
using Models;

/// <summary>Sent by the client when registering a new client to the server</summary>
public record RegisterRequest(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("voucher")]
    string Voucher,
    [property: JsonPropertyName("name")] string Name
) : IHashtopolisRequest
{
    private IHashSlingerRepository _repository = new HashSlingerRepository();


    /// <inheritdoc />
    public async Task<IHashtopolisMessage> ProcessRequestAsync(IHashSlingerRepository repository)
    {
        RegistrationVoucher voucher
            = await repository.GetRegistrationVoucherAsync(Voucher).ConfigureAwait(true);

        if (voucher == null) return new RegisterResponse(Action, "ERROR", "Voucher not found");

        if (voucher.Expiration < DateTime.Now)
            return new RegisterResponse(Action, "ERROR", "Voucher expired");
        if (voucher.Voucher == Voucher)
            return new RegisterResponse(Action, "SUCCESS", voucher.GetRandomToken());
        return null!;
    }
}
