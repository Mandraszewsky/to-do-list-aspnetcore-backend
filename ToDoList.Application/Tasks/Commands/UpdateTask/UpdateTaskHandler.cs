using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoList.Application.CQRS;
using ToDoList.Application.Data;

namespace ToDoList.Application.Tasks.Commands.UpdateTask;

public class UpdateTaskHandler(IApplicationDbContext dbContext, IMapper mapper) : ICommandHandler<UpdateTaskCommand, UpdateTaskResult>
{
    public async Task<UpdateTaskResult> Handle(UpdateTaskCommand command, CancellationToken cancellationToken)
    {
        var task = await dbContext.Tasks.FirstOrDefaultAsync(a => a.Id == command.Task.Id, cancellationToken);

        if (task is null)
            throw new Exception("Task not found.");

        mapper.Map(command.Task, task);

        dbContext.Tasks.Update(task);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateTaskResult(true);
    }
}
