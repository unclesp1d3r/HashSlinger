namespace HashSlinger.Api.Endpoints.User;

using HashSlinger.Api.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/User").WithTags(nameof(User));

        group.MapGet("/", async (HashSlingerContext db) => { return await db.Users.ToListAsync(); })
            .WithName("GetAllUsers")
            .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Models.User>, NotFound>> (int id, HashSlingerContext db) =>
            {
                return await db.Users.AsNoTracking()
                        .FirstOrDefaultAsync(model => model.Id == id)
                    is Models.User model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
            })
            .WithName("GetUserById")
            .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Models.User user, HashSlingerContext db) =>
            {
                var affected = await db.Users
                    .Where(model => model.Id == id)
                    .ExecuteUpdateAsync(setters => setters
                        .SetProperty(m => m.Id, user.Id)
                        .SetProperty(m => m.Username, user.Username)
                        .SetProperty(m => m.Email, user.Email)
                        .SetProperty(m => m.PasswordHash, user.PasswordHash)
                        .SetProperty(m => m.PasswordSalt, user.PasswordSalt)
                        .SetProperty(m => m.IsValid, user.IsValid)
                        .SetProperty(m => m.LastLoginDate, user.LastLoginDate)
                        .SetProperty(m => m.RegisteredSince, user.RegisteredSince)
                        .SetProperty(m => m.SessionLifetime, user.SessionLifetime)
                    );

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("UpdateUser")
            .WithOpenApi();

        group.MapPost("/", async (Models.User user, HashSlingerContext db) =>
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/User/{user.Id}", user);
            })
            .WithName("CreateUser")
            .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, HashSlingerContext db) =>
            {
                var affected = await db.Users
                    .Where(model => model.Id == id)
                    .ExecuteDeleteAsync();

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("DeleteUser")
            .WithOpenApi();
    }
}
