using BuildingBlocks.Abstractions.CQRS.Events.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Abstractions.Domain;

public interface IHaveAggregate : IHaveAggregateVersion
{
    public bool HasUncommittedDomainEvents();
    IReadOnlyList<IDomainEvent> GetUncommittedDomainEvents();
    void MarkUncommittedDomainEventAsCommitted();
    void CheckRule(IBusinessRule rule);
}
