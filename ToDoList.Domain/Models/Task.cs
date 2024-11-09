using ToDoList.Domain.Abstractions;

namespace ToDoList.Domain.Models;

public class Task : Entity<Guid>
{
    public Guid UserId { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Summary { get; set; } = default!;
    public DateTime DueDate { get; set; }

    public static Task Create(Guid id, Guid userId, string title, string summary, DateTime dueTime)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        ArgumentException.ThrowIfNullOrWhiteSpace(summary);

        var task = new Task { Id = id, UserId = userId,  Title = title, Summary = summary, DueDate = dueTime };

        return task;
    }
}
