namespace HashSlinger.Api.Handlers.Commands;

using Data;
using MediatR;
using Models;
using Task = Task;

/// <summary>Represents a command to perform the initial setup of the application.</summary>
/// <seealso cref="MediatR.IRequest" />
/// <seealso cref="MediatR.IBaseRequest" />
public record PerformInitialSetupCommand : IRequest;

/// <summary>Handles the initial setup of the application.</summary>
// ReSharper disable once UnusedMember.Global
public class PerformInitialSetupHandler : IRequestHandler<PerformInitialSetupCommand>
{
    private readonly HashSlingerContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="PerformInitialSetupHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    public PerformInitialSetupHandler(HashSlingerContext dbContext) => _dbContext = dbContext;

    /// <summary>Handles a request</summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    public Task Handle(PerformInitialSetupCommand request, CancellationToken cancellationToken)
    {
        // Clean up the database.
        _dbContext.Agents.RemoveRange(_dbContext.Agents);
        _dbContext.Users.RemoveRange(_dbContext.Users);
        _dbContext.RegistrationVouchers.RemoveRange(_dbContext.RegistrationVouchers);
        _dbContext.AccessGroups.RemoveRange(_dbContext.AccessGroups);
        _dbContext.SaveChanges();

        var defaultGroup = new AccessGroup { Name = "Default" };
        _dbContext.AccessGroups.Add(defaultGroup);
        var admin = new User
        {
            Email = "admin@localhost", UserName = "admin",
            RegisteredSince = DateTime.UtcNow
        };
        admin.SetPasswordHash("admin");
        defaultGroup.Users.Add(admin);
        _dbContext.Users.Add(admin);
        _dbContext.RegistrationVouchers.Add(new RegistrationVoucher
        { Voucher = "abcd", AccessGroup = defaultGroup });
        _dbContext.SaveChanges();

        return Task.CompletedTask;
    }
}
