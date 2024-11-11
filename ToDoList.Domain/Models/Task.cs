using ToDoList.Domain.Abstractions;
using ToDoList.Domain.Events;

namespace ToDoList.Domain.Models;

public class Task : Aggregate<Guid>
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

        task.AddDomainEvent(new TaskCreatedEvent(task));

        return task;
    }

    public void Update(Guid userId, string title, string summary, DateTime dueTime)
    {
        UserId = userId;
        Title= title;
        Summary = summary;
        DueDate = dueTime;

        AddDomainEvent(new TaskUpdatedEvent(this));
    }

    public void DomainUpdateEvent()
    {
        AddDomainEvent(new TaskUpdatedEvent(this));
    }

    public void DomainCreateEvent()
    {
        AddDomainEvent(new TaskCreatedEvent(this));
    }
}
