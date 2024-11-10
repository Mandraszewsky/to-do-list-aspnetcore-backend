namespace ToDoList.Application.Dtos;

public record CreateTaskDto(Guid UserId, string Title, string Summary, string DueDate);
