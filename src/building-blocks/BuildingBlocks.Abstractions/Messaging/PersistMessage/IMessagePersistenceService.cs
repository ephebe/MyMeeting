using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.CQRS.Events.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Abstractions.Messaging.PersistMessage;

/// <summary>
/// 就是把消息存往DB
/// 也執行在DB中的消息進行發送，Co
/// </summary>
public interface IMessagePersistenceService
{
    Task<IReadOnlyList<StoreMessage>> GetByFilterAsync(
        Expression<Func<StoreMessage, bool>>? predicate = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 消息存入OutBox
    /// </summary>
    /// <typeparam name="TMessageEnvelope"></typeparam>
    /// <param name="messageEnvelope"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddPublishMessageAsync<TMessageEnvelope>(
        TMessageEnvelope messageEnvelope,
        CancellationToken cancellationToken = default)
        where TMessageEnvelope : MessageEnvelope;

    /// <summary>
    /// 消息存入InBox
    /// </summary>
    /// <typeparam name="TMessageEnvelope"></typeparam>
    /// <param name="messageEnvelope"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddReceivedMessageAsync<TMessageEnvelope>(
        TMessageEnvelope messageEnvelope,
        CancellationToken cancellationToken = default)
        where TMessageEnvelope : MessageEnvelope;

    /// <summary>
    /// Command存入內部信箱
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <param name="internalCommand"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddInternalMessageAsync<TCommand>(
        TCommand internalCommand,
        CancellationToken cancellationToken = default)
        where TCommand : class, IInternalCommand;

    /// <summary>
    /// 非同步事件存入內部信箱
    /// </summary>
    /// <param name="notification"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddNotificationAsync(
        IDomainNotificationEvent notification,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 對存入的信息，進行處理。OutBox的叫Bus送，Command還有非同步事件的叫MedaitR送
    /// </summary>
    /// <param name="messageId"></param>
    /// <param name="deliveryType"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task ProcessAsync(Guid messageId, MessageDeliveryType deliveryType, CancellationToken cancellationToken = default);

    Task ProcessAllAsync(CancellationToken cancellationToken = default);
}
