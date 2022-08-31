using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Abstractions.Messaging.PersistMessage;

public interface IMessagePersistenceRepository
{
    Task AddAsync(StoreMessage storeMessage, CancellationToken cancellationToken = default);
    Task UpdateAsync(StoreMessage storeMessage, CancellationToken cancellationToken = default);

    Task ChangeStateAsync(
        Guid messageId,
        MessageStatus status,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<StoreMessage>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<IReadOnlyList<StoreMessage>> GetByFilterAsync(
        Expression<Func<StoreMessage, bool>> predicate,
        CancellationToken cancellationToken = default);

    Task<StoreMessage?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> RemoveAsync(StoreMessage storeMessage, CancellationToken cancellationToken = default);

    Task CleanupMessages();
}
