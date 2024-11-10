namespace ToDoList.Application.Dtos;

public record UpdateTaskDto(Guid Id, string Title, string Summary, string DueDate);