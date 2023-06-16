﻿namespace HashSlinger.Api.Handlers.Queries;

using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models;
using Serilog;

/// <summary>Represents a query to retrieve the registration voucher.</summary>
public record GetRegistrationVoucherQuery(string Voucher) : IRequest<RegistrationVoucher?>;

/// <summary>Handles retrieving the registration voucher.</summary>
public class
    GetRegistrationVoucherHandler : IRequestHandler<GetRegistrationVoucherQuery, RegistrationVoucher?>
{
    private readonly HashSlingerContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="GetRegistrationVoucherHandler" /> class.</summary>
    /// <param name="dbContext">The database context.</param>
    public GetRegistrationVoucherHandler(HashSlingerContext dbContext) => _dbContext = dbContext;

    /// <summary>Handles a request</summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    public Task<RegistrationVoucher?> Handle(
        GetRegistrationVoucherQuery request,
        CancellationToken cancellationToken
    )
    {
        Log.Debug("Getting voucher {voucher}", request.Voucher);
        return _dbContext.RegistrationVouchers.Include(r => r.AccessGroup)
            .SingleOrDefaultAsync(v => v.Voucher == request.Voucher, cancellationToken);
    }
}