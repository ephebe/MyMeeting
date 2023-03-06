using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Abstractions.CQRS.Events.Internal;
using BuildingBlocks.Core.Messaging;

namespace BuildingBlocks.Core.CQRS.Events.Internal;

public record IntegrationEventWrapper<TDomainEventType>
    : IntegrationEvent
    where TDomainEventType : IDomainEvent;
