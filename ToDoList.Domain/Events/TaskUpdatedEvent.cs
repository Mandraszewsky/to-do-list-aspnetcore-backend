using ToDoList.Domain.Abstractions;

namespace ToDoList.Domain.Events;

public record TaskUpdatedEvent(Domain.Models.Task task) : IDomainEvent;
