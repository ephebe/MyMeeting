using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Abstractions.CQRS.Events.Internal;

/// <summary>
/// 裏面包著IMessagePersistenceService，僅針對非同步事件進行操作
/// </summary>
public interface IDomainNotificationEventPublisher
{
    Task PublishAsync(IDomainNotificationEvent domainNotificationEvent, CancellationToken cancellationToken = default);

    Task PublishAsync(
        IDomainNotificationEvent[] domainNotificationEvents,
        CancellationToken cancellationToken = default);
}
