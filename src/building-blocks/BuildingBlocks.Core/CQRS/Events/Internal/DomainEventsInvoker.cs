﻿using BuildingBlocks.Abstractions.CQRS.Events;
using BuildingBlocks.Abstractions.CQRS.Events.Internal;

namespace BuildingBlocks.Core.CQRS.Events.Internal;

public static class DomainEventsInvoker
{
    private static readonly Func<IEventProcessor> _eventProcessorFunc =
        ServiceActivator.GetScope().ServiceProvider.GetRequiredService<IEventProcessor>;

    public static async Task RaiseDomainEventAsync(
        IDomainEvent[] domainEvents,
        CancellationToken cancellationToken = default)
    {
        var eventProcessor = _eventProcessorFunc.Invoke();
        foreach (var domainEvent in domainEvents)
        {
            await eventProcessor.DispatchAsync(domainEvent, cancellationToken: cancellationToken);
        }
    }

    public static Task RaiseDomainEventAsync(
        IDomainEvent domainEvent,
        CancellationToken cancellationToken = default)
    {
        var eventProcessor = _eventProcessorFunc.Invoke();
        return eventProcessor.DispatchAsync(domainEvent, cancellationToken: cancellationToken);
    }

    public static void RaiseDomainEvent(
        IDomainEvent domainEvent,
        CancellationToken cancellationToken = default)
    {
        var eventProcessor = _eventProcessorFunc.Invoke();
        eventProcessor.DispatchAsync(domainEvent, cancellationToken: cancellationToken).GetAwaiter().GetResult();
    }
}
