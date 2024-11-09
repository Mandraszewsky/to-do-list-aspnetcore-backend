using Microsoft.EntityFrameworkCore;
using ToDoList.Application.CQRS;
using ToDoList.Application.Data;

namespace ToDoList.Application.Tasks.Commands.DeleteTask;

public class DeleteTaskHandler(IApplicationDbContext dbContext) : ICommandHandler<DeleteTaskCommand, DeleteTaskResult>
{
    public async Task<DeleteTaskResult> Handle(DeleteTaskCommand command, CancellationToken cancellationToken)
    {
        var task = await dbContext.Tasks.FirstOrDefaultAsync(a => a.Id == command.TaskId, cancellationToken);

        if (task is null)
            throw new Exception("Task not found");

        dbContext.Tasks.Remove(task);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteTaskResult(true);
    }
}