using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Data;
using ToDoList.Application.Exceptions;

namespace ToDoList.Application.CQRS.Tasks.Commands.DeleteTask;

public class DeleteTaskHandler(IApplicationDbContext dbContext) : ICommandHandler<DeleteTaskCommand, DeleteTaskResult>
{
    public async Task<DeleteTaskResult> Handle(DeleteTaskCommand command, CancellationToken cancellationToken)
    {
        var task = await dbContext.Tasks.FirstOrDefaultAsync(a => a.Id == command.TaskId, cancellationToken);

        if (task is null)
            throw new TaskNotFoundException();

        dbContext.Tasks.Remove(task);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteTaskResult(true);
    }
}