using ToDoList.Domain.Abstractions;

namespace ToDoList.Domain.Events;

public record TaskCreatedEvent(Domain.Models.Task task) : IDomainEvent;