namespace HashSlinger.Api.Handlers.Commands;

using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models;
using Serilog;
using Task = System.Threading.Tasks.Task;

/// <summary>Represents a command to delete a registration voucher.</summary>
public record DeleteRegistrationVoucherCommand(int Id) : IRequest;

/// <summary>Handles removing a registration voucher from the database.</summary>

// ReSharper disable once UnusedMember.Global
// ReSharper disable once UnusedType.Global
public class DeleteRegistrationVoucherCommandHandler : IRequestHandler<DeleteRegistrationVoucherCommand>
{
    private readonly HashSlingerContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="DeleteRegistrationVoucherCommandHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    public DeleteRegistrationVoucherCommandHandler(HashSlingerContext dbContext) => _dbContext = dbContext;

    /// <summary>Handles a request</summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    public async Task Handle(DeleteRegistrationVoucherCommand request, CancellationToken cancellationToken)
    {
        RegistrationVoucher? voucher = await _dbContext.RegistrationVouchers
            .SingleOrDefaultAsync(r => r.Id == request.Id, cancellationToken)
            .ConfigureAwait(true);

        if (voucher == null)
        {
            Log.Warning("Voucher not found");
            return;
        }

        _dbContext.RegistrationVouchers.Remove(voucher);
        await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(true);
    }
}
