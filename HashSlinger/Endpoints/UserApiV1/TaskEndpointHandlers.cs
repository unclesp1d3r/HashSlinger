namespace HashSlinger.Api.Endpoints.UserApiV1;

using Data;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Shared.Generated;
using Shared.Models;
using Shared.Models.Enums;

/// <summary>Holds the handlers for the Task endpoints.</summary>
public static class TaskEndpointHandlers
{
    /// <summary>Handles creating a task.</summary>
    /// <param name="task">The task.</param>
    /// <param name="db">The database.</param>
    public async static Task<Created<TaskDto>> CreateTaskHandlerAsync(TaskDto task, HashSlingerContext db)
    {
        db.Tasks.Add(task.Adapt<Task>());
        await db.SaveChangesAsync().ConfigureAwait(true);
        return TypedResults.Created($"{UserApiEndPoints.ApiPrefix}/Task/{task.Id}", task);
    }

    /// <summary>Handles deleting a task.</summary>
    /// <param name="id">The task identifier.</param>
    /// <param name="db">The database.</param>
    public async static Task<Results<Ok, NotFound>> DeleteTaskHandlerAsync(int id, HashSlingerContext db)
    {
        var affected = await db.Tasks.Where(model => model.Id == id).ExecuteDeleteAsync().ConfigureAwait(true);

        return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
    }

    /// <summary>Handles getting all tasks.</summary>
    /// <param name="db">The database.</param>
    public static Task<List<TaskDto>> GetAllTasksHandlerAsync(HashSlingerContext db)
    {
        return db.Tasks.Include(t => t.TaskWrapper).ProjectToType<TaskDto>().AsSplitQuery().ToListAsync();
    }

    /// <summary>Handles getting a task by its identifier.</summary>
    /// <param name="id">The task identifier.</param>
    /// <param name="db">The database.</param>
    public async static Task<Results<Ok<TaskDto>, NotFound>> GetTaskByIdHandlerAsync(int id, HashSlingerContext db)
    {
        return await db.Tasks.Include(t => t.TaskWrapper)
                       .ThenInclude(t => t.Hashlist)
                       .Include(t => t.CrackerBinary)
                       .Include(t => t.CrackerBinaryType)
                       .ProjectToType<TaskDto>()
                       .AsSplitQuery()
                       .AsNoTracking()
                       .FirstOrDefaultAsync(model => model.Id == id)
                       .ConfigureAwait(true) is TaskDto model
                   ? TypedResults.Ok(model)
                   : TypedResults.NotFound();
    }

    /// <summary>Handles updating</summary>
    /// <param name="id">The identifier.</param>
    /// <param name="task">The task.</param>
    /// <param name="db">The database.</param>
    public async static Task<Results<Ok, NotFound>> UpdateTaskHandlerAsync(int id, TaskDto task, HashSlingerContext db)
    {
        var affected = await db.Tasks.Where(model => model.Id == id)
                               .ExecuteUpdateAsync(setters => setters.SetProperty(m => m.AttackCommand, task.AttackCommand)
                                                                     .SetProperty(m => m.ChunkSize, task.ChunkSize)
                                                                     .SetProperty(m => m.ChunkTime, task.ChunkTime)
                                                                     .SetProperty(m => m.Color, task.Color)
                                                                     .SetProperty(m => m.EnforcePipe, task.EnforcePipe)
                                                                     .SetProperty(m => m.Id, task.Id)
                                                                     .SetProperty(m => m.IsArchived, task.IsArchived)
                                                                     .SetProperty(m => m.IsCpuTask, task.IsCpuTask)
                                                                     .SetProperty(m => m.IsSmall, task.IsSmall)
                                                                     .SetProperty(m => m.Keyspace, task.Keyspace)
                                                                     .SetProperty(m => m.KeyspaceProgress,
                                                                         task.KeyspaceProgress)
                                                                     .SetProperty(m => m.MaxAgents, task.MaxAgents)
                                                                     .SetProperty(m => m.Name, task.Name)
                                                                     .SetProperty(m => m.Notes, task.Notes)
                                                                     .SetProperty(m => m.PreprocessorCommand,
                                                                         task.PreprocessorCommand)
                                                                     .SetProperty(m => m.Priority, task.Priority)
                                                                     .SetProperty(m => m.SkipKeyspace, task.SkipKeyspace)
                                                                     .SetProperty(m => m.StaticChunks,
                                                                         task.StaticChunks.Adapt<TaskStaticChunking>())
                                                                     .SetProperty(m => m.StatusTimer, task.StatusTimer)
                                                                     .SetProperty(m => m.TaskWrapperId, task.TaskWrapperId)
                                                                     .SetProperty(m => m.UseNewBenchmark,
                                                                         task.UseNewBenchmark)
                                                                     .SetProperty(m => m.UsePreprocessor,
                                                                         task.UsePreprocessor))
                               .ConfigureAwait(true);

        if (affected != 1) return TypedResults.NotFound();

        Task? modifiedTask = await db.Tasks.Include(t => t.TaskWrapper)
                                     .Where(model => model.Id == id)
                                     .SingleOrDefaultAsync()
                                     .ConfigureAwait(true);
        if (task.TaskWrapper is not null) modifiedTask!.TaskWrapper.HashlistId = task.TaskWrapper.HashlistId;
        if (task.CrackerBinary is not null) modifiedTask!.CrackerBinaryId = task.CrackerBinary.Id;
        db.Tasks.Update(modifiedTask!);
        await db.SaveChangesAsync().ConfigureAwait(true);

        return TypedResults.Ok();
    }
}
