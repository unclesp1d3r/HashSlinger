namespace HashSlinger.Api.Endpoints.HashtopolisApiV2.Handlers;

using Api.Handlers.Commands;
using Api.Handlers.Queries;
using DTO;
using Mapster;
using MediatR;
using Models;
using Models.Enums;
using Serilog;

/// <summary>Handles the Hashtopolis register call.</summary>

// ReSharper disable once UnusedType.Global
public class RegisterHandler : IRequestHandler<RegisterRequest, RegisterResponse>
{
    private readonly IMediator _mediator;

    /// <summary>Initializes a new instance of the <see cref="RegisterHandler" /> class.</summary>
    /// <param name="mediator">The mediator</param>
    public RegisterHandler(IMediator mediator) => _mediator = mediator;

    /// <inheritdoc />
    public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        RegistrationVoucher? voucher = await _mediator
                                             .Send(new GetRegistrationVoucherQuery(request.Voucher),
                                                 cancellationToken)
                                             .ConfigureAwait(true);
        if (voucher == null)
        {
            Log.Error("Voucher not found");
            return this.Adapt<RegisterResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Voucher not found."
            };
        }

        if (voucher.Expiration.HasValue && voucher.Expiration < DateTime.Now)
        {
            Log.Error("Voucher expired");
            return this.Adapt<RegisterResponse>() with
            {
                Response = HashtopolisConstants.ErrorResponse,
                Message = "Voucher expired."
            };
        }

        if (voucher.Voucher != request.Voucher)
        {
            Log.Error("Voucher does not match");
            return new RegisterResponse(request.Action,
                HashtopolisConstants.ErrorResponse,
                string.Empty,
                "Voucher does not match.");
        }

        User user = await _mediator.Send(new GetDefaultUserQuery(), cancellationToken).ConfigureAwait(true);
        var newAgent = new Agent
        {
            Name = request.Name,
            LastAction = AgentActions.Register,
            LastSeenTime = DateTime.UtcNow,
            Token = RegistrationVoucher.GetRandomToken(),
            User = user
        };
        if (voucher.AccessGroup != null) newAgent.AccessGroups.Add(voucher.AccessGroup);

        //int result = await _repository.CreateAgentAsync(newAgent).ConfigureAwait(true);
        int result = await _mediator.Send(new CreateAgentCommand(newAgent), cancellationToken)
                                    .ConfigureAwait(true);
        if (result == 0)
        {
            Log.Error("Failed to create agent");
            return new RegisterResponse(request.Action, "ERROR", string.Empty, "Failed to create agent");
        }

        if (voucher.Expiration != null)
            await _mediator.Send(new DeleteRegistrationVoucherCommand(voucher.Id), cancellationToken)
                           .ConfigureAwait(true);
        Log.Debug("Created agent {AgentName} with token {AgentToken}", newAgent.Name, newAgent.Token);
        return new RegisterResponse(request.Action, HashtopolisConstants.SuccessResponse, newAgent.Token);
    }
}
