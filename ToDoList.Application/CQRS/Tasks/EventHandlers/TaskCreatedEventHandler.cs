using MediatR;
using Microsoft.Extensions.Logging;
using ToDoList.Domain.Events;

namespace ToDoList.Application.CQRS.Tasks.EventHandlers;

public class TaskCreatedEventHandler(ILogger<TaskCreatedEventHandler> logger) : INotificationHandler<TaskCreatedEvent>
{
    public Task Handle(TaskCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", domainEvent.GetType().Name);

        return Task.CompletedTask;
    }
}
