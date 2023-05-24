namespace HashSlinger.Api.Endpoints.HashtopolisApiV2;

using System;
using System.Security.Cryptography;
using HashSlinger.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

/// <summary>
/// Maps the endpoints for the Hashtopolis API.
/// </summary>
public static class HashtopolisEndpoints
{
    /// <summary>Maps the hashtopolis endpoints.</summary>
    /// <param name="routes">The routes.</param>
    public static void MapHashtopolisEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Hashtopolis");

        group.MapGet("/", () => "TODO!")
            .WithOpenApi();
        group.MapPost("/", (HashtopolisRequest request) => { Console.WriteLine(request); });
    }
}
