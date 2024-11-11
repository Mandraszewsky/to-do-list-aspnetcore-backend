using AutoMapper;
using ToDoList.Application.Data;

namespace ToDoList.Application.CQRS.Tasks.Commands.CreateTask;

public class CreateTaskHandler(IApplicationDbContext dbContext, IMapper mapper) : ICommandHandler<CreateTaskCommand, CreateTaskResult>
{
    public async Task<CreateTaskResult> Handle(CreateTaskCommand command, CancellationToken cancellationToken)
    {
        var task = mapper.Map<Domain.Models.Task>(command.Task);

        task.DomainCreateEvent();

        dbContext.Tasks.Add(task);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateTaskResult(task.Id);
    }
}
