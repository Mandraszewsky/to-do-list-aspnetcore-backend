using ToDoList.Application.CQRS;

namespace ToDoList.Application.Tasks.Queries;

public record GetTasksResult(List<Domain.Models.Task>? Tasks);
public record GetTasksQuery() : IQuery<GetTasksResult>;
