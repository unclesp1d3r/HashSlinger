﻿namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.DTO;

using System.Text.Json.Serialization;
using Data;

/// <inheritdoc />
public record TestConnectionRequest
    ([property: JsonPropertyName("action")] string Action) : IHashtopolisRequest
{
    /// <inheritdoc />
    public Task<IHashtopolisMessage> ProcessRequestAsync(HashSlingerContext db, ILogger logger)
    {
        logger.LogDebug("TestConnectionRequest received");
        return Task.FromResult<IHashtopolisMessage>(new TestConnectionResponse("testConnection", "SUCCESS"));
    }
}
