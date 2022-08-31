using BuildingBlocks.Abstractions.CQRS.Events;
using BuildingBlocks.Abstractions.CQRS.Events.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Core.CQRS.Events;

public class NullDomainEventsAccessor : IDomainEventsAccessor
{
    public IReadOnlyList<IDomainEvent> UnCommittedDomainEvents { get; }
}
