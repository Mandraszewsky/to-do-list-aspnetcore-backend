namespace ToDoList.Application.CQRS.Tasks.Queries.GetTasks;

public record GetTasksResult(List<Domain.Models.Task>? Tasks);
public record GetTasksQuery() : IQuery<GetTasksResult>;
