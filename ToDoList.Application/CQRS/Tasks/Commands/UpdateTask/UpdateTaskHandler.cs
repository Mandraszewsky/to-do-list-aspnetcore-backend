using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Data;
using ToDoList.Application.Exceptions;

namespace ToDoList.Application.CQRS.Tasks.Commands.UpdateTask;

public class UpdateTaskHandler(IApplicationDbContext dbContext, IMapper mapper) : ICommandHandler<UpdateTaskCommand, UpdateTaskResult>
{
    public async Task<UpdateTaskResult> Handle(UpdateTaskCommand command, CancellationToken cancellationToken)
    {
        var task = await dbContext.Tasks.FirstOrDefaultAsync(a => a.Id == command.Task.Id, cancellationToken);

        if (task is null)
            throw new TaskNotFoundException();

        mapper.Map(command.Task, task);

        task.DomainUpdateEvent();

        dbContext.Tasks.Update(task);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateTaskResult(true);
    }
}
