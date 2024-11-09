using FluentValidation;
using ToDoList.Application.CQRS;

namespace ToDoList.Application.Tasks.Commands.DeleteTask;

public record DeleteTaskResult(bool IsSuccess);
public record DeleteTaskCommand(Guid TaskId) : ICommand<DeleteTaskResult>;

public class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
{
    public DeleteTaskCommandValidator()
    {
        RuleFor(x => x.TaskId).NotEmpty().WithMessage("Id is required)");
    }
}
