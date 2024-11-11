namespace ToDoList.Application.Dtos;

public record TaskFilterDto(Guid UserId, string? Title, string? Summary, string? DueDate);
