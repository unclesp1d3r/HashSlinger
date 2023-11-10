namespace HashSlinger.Api.Endpoints.UserApiV1;

using Data;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Shared.Generated;
using Shared.Models;

/// <summary>Holds the handlers for the RegistrationVoucher endpoints</summary>
public static class RegistrationVoucherEndpointHandlers
{
    /// <summary>Creates the registration voucher. POST /api/v1/RegistrationVoucher</summary>
    public async static Task<Created<RegistrationVoucherDto>> CreateRegistrationVoucherHandlerAsync(
        RegistrationVoucherDto registrationVoucherDto,
        HashSlingerContext db
    )
    {
        db.RegistrationVouchers.Add(registrationVoucherDto.Adapt<RegistrationVoucher>());
        await db.SaveChangesAsync().ConfigureAwait(true);
        return TypedResults.Created($"{UserApiEndPoints.ApiPrefix}/RegistrationVoucher/{registrationVoucherDto.Id}",
            registrationVoucherDto);
    }

    /// <summary>Handles deleting a RegistrationVoucher DELETE /api/v1/RegistrationVoucher/{id}</summary>
    public async static Task<Results<Ok, NotFound>> DeleteRegistrationVoucherHandlerAsync(int id, HashSlingerContext db)
    {
        var affected = await db.RegistrationVouchers.Where(model => model.Id == id)
                               .ExecuteDeleteAsync()
                               .ConfigureAwait(true);

        return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
    }

    /// <summary>Gets all registration vouchers. GET /api/v1/RegistrationVoucher</summary>
    public static Task<List<RegistrationVoucherDto>> GetAllRegistrationVouchersHandlerAsync(HashSlingerContext db)
    {
        return db.RegistrationVouchers.ProjectToType<RegistrationVoucherDto>().AsSplitQuery().ToListAsync();
    }

    /// <summary>Gets the registration voucher by identifier. GET /api/v1/RegistrationVoucher/{id}</summary>
    public async static Task<Results<Ok<RegistrationVoucherDto>, NotFound>> GetRegistrationVoucherByIdHandlerAsync(
        int id,
        HashSlingerContext db
    )
    {
        return await db.RegistrationVouchers.ProjectToType<RegistrationVoucherDto>()
                       .AsNoTracking()
                       .AsSplitQuery()
                       .FirstOrDefaultAsync(model => model.Id == id)
                       .ConfigureAwait(true) is RegistrationVoucherDto model
                   ? TypedResults.Ok(model)
                   : TypedResults.NotFound();
    }

    /// <summary>Handles updating a RegistrationVoucher PUT /api/v1/RegistrationVoucher/{id}</summary>
    public async static Task<Results<Ok, NotFound>> UpdateRegistrationVoucherHandlerAsync(
        int id,
        RegistrationVoucherDto registrationVoucherDto,
        HashSlingerContext db
    )
    {
        var affected = await db.RegistrationVouchers.Where(model => model.Id == id)
                               .ExecuteUpdateAsync(setters =>
                                   setters.SetProperty(m => m.Expiration, registrationVoucherDto.Expiration)
                                          .SetProperty(m => m.Id, registrationVoucherDto.Id)
                                          .SetProperty(m => m.Voucher, registrationVoucherDto.Voucher))
                               .ConfigureAwait(true);

        return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
    }
}
