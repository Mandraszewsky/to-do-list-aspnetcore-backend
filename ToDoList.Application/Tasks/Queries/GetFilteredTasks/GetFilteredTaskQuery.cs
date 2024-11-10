using ToDoList.Application.CQRS;
using ToDoList.Application.Dtos;

namespace ToDoList.Application.Tasks.Queries.GetFilteredTasks;

public record GetFilteredTasksResult(List<Domain.Models.Task>? Tasks);
public record GetFilteredTaskQuery(TaskFilterDto Task) : IQuery<GetFilteredTasksResult>;
