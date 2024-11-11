﻿using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Abstractions;

namespace ToDoList.Infrastructure.Data.Interceptors;

public class DispatchDomainEventsInterceptor(IMediator mediator) : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        DispatchDomainEvents(eventData.Context).GetAwaiter().GetResult();
        return base.SavingChanges(eventData, result);
    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        await DispatchDomainEvents(eventData.Context);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public async Task DispatchDomainEvents(DbContext? context)
    {
        if (context is null)
            return;

        var aggregates = context.ChangeTracker
            .Entries<IAggregate>()
            .Where(x => x.Entity.DomainEvents.Any())
            .Select(x => x.Entity);

        var domainEvenets = aggregates
            .SelectMany(x => x.DomainEvents)
            .ToList();

        aggregates.ToList().ForEach(x => x.ClearDomainEvenets());

        foreach (var domainEvent in domainEvenets)
            await mediator.Publish(domainEvent);
    }
}
