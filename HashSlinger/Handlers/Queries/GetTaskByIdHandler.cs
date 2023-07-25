namespace HashSlinger.Api.Handlers.Queries;

using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

public record GetTaskByIdQuery(string Token, int TaskId) : IRequest<Task?>;

public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, Task?>
{
    private readonly HashSlingerContext _context;
    public GetTaskByIdHandler(HashSlingerContext context) => _context = context;

    /// <inheritdoc />
    public async Task<Task?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        Agent? agent = await _context.Agents.SingleOrDefaultAsync(x => x.Token == request.Token, cancellationToken)
                                     .ConfigureAwait(false);
        if (agent is null) return null;
        Task? task = await _context.Tasks.Include(t => t.TaskWrapper)
                                   .Include(t => t.Chunks)
                                   .Include(t => t.Assignments)
                                   .AsSplitQuery()
                                   .SingleOrDefaultAsync(x => x.Id == request.TaskId, cancellationToken)
                                   .ConfigureAwait(false);
        return task;
    }
}
