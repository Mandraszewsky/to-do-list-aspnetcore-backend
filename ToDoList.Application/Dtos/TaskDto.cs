namespace ToDoList.Application.Dtos;

public record TaskDto(Guid Id, Guid UserId, string Title, string Summary, DateTime DueDate);
