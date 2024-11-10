using FluentValidation;
using ToDoList.Application.CQRS;
using ToDoList.Application.Dtos;

namespace ToDoList.Application.Tasks.Commands.UpdateTask;

public record UpdateTaskResult(bool IsSuccess);
public record UpdateTaskCommand(UpdateTaskDto Task) : ICommand<UpdateTaskResult>;

public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
{
    public UpdateTaskCommandValidator()
    {
        RuleFor(x => x.Task.Id).NotEmpty().WithMessage("Id is required)");
        RuleFor(x => x.Task.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(x => x.Task.Summary).NotEmpty().WithMessage("Summary is required");
        RuleFor(x => x.Task.DueDate).NotEmpty().WithMessage("DueDate is required");
    }
}
