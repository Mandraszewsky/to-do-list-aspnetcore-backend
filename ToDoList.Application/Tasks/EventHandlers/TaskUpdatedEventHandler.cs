using MediatR;
using Microsoft.Extensions.Logging;
using ToDoList.Domain.Events;

namespace ToDoList.Application.Tasks.EventHandlers;

public class TaskUpdatedEventHandler(ILogger<TaskUpdatedEventHandler> logger) : INotificationHandler<TaskUpdatedEvent>
{
    public Task Handle(TaskUpdatedEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", domainEvent.GetType().Name);

        return Task.CompletedTask;
    }
}