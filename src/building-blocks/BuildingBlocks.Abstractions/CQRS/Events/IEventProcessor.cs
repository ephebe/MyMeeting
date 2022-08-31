using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Abstractions.CQRS.Events;

/// <summary>
/// Dispatch只是MediatR.Publish簡單包覆
/// Publish則是整合方法，對內部事件(MediarR.Publish)，非同步事件(Save)、整合事件(Save)
/// </summary>
public interface IEventProcessor
{
    public Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
        where TEvent : IEvent;

    public Task PublishAsync<TEvent>(TEvent[] events, CancellationToken cancellationToken = default)
        where TEvent : IEvent;

    public Task DispatchAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
        where TEvent : IEvent;

    public Task DispatchAsync<TEvent>(TEvent[] events, CancellationToken cancellationToken = default)
        where TEvent : IEvent;
}
