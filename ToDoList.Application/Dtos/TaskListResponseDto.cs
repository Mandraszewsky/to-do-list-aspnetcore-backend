namespace ToDoList.Application.Dtos;

public class TaskListResponseDto
{
    public List<Domain.Models.Task> Tasks { get; set;} = new List<Domain.Models.Task>();
}
