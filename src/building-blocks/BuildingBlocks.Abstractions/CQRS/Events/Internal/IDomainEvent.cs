using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Abstractions.CQRS.Events.Internal;

public interface IDomainEvent : IEvent
{
    dynamic AggregateId { get; }
    long AggregateSequenceNumber { get; }

    public IDomainEvent WithAggregate(dynamic aggregateId, long version);
}
