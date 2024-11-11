using FluentValidation;
using ToDoList.Application.Dtos;

namespace ToDoList.Application.CQRS.Tasks.Commands.CreateTask;

public record CreateTaskResult(Guid Id);
public record CreateTaskCommand(CreateTaskDto Task) : ICommand<CreateTaskResult>;

public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskCommandValidator()
    {
        RuleFor(x => x.Task.UserId).NotEmpty().WithMessage("UserId is required");
        RuleFor(x => x.Task.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(x => x.Task.Summary).NotEmpty().WithMessage("Summary is required");
    }
}
