﻿namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using DAL;
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
            Log.Information("Voucher not found");
            return new RegisterResponse(Action,
                HashtopolisConstants.ErrorResponse,
                string.Empty,
                "Voucher not found.");
        }

        if (voucher.Expiration < DateTime.Now)
        {
            Log.Information("Voucher expired");
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

        var newAgent = new Agent
        {
            Name = Name,
            LastAction = AgentActions.Register,
            LastSeenTime = DateTime.UtcNow,
            Token = voucher.GetRandomToken()
        };

        int result = await repository.CreateAgentAsync(newAgent).ConfigureAwait(true);

        if (result == 0)
        {
            Log.Error("Failed to create agent");
            return new RegisterResponse(Action, "ERROR", string.Empty, "Failed to create agent");
        }

        await repository.DeleteRegistrationVoucherAsync(voucher).ConfigureAwait(true);
        Log.Debug("Created agent {AgentName} with token {AgentToken}", newAgent.Name, newAgent.Token);
        return new RegisterResponse(Action, HashtopolisConstants.SuccessResponse, newAgent.Token, null);
    }
}
