﻿using MediatR;

namespace ToDoList.Domain.Abstractions;

public interface IDomainEvent : INotification
{
    Guid EventId => Guid.NewGuid();
    public DateTime OccurrenOn => DateTime.Now;
    public string? EventType => GetType().AssemblyQualifiedName;
}

