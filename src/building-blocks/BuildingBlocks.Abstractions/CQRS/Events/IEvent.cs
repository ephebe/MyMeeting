using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Abstractions.CQRS.Events;

public interface IEvent : INotification
{
    Guid EventId { get; }
    long EventVersion { get; }
    DateTime OccurredOn { get; }
    DateTimeOffset TimeStamp { get; }
    public string EventType { get; }
}
