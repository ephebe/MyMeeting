using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Abstractions.Persistence;

public interface ITxDbContextExecution
{
    public Task ExecuteTransactionalAsync(Func<Task> action, CancellationToken cancellationToken = default);
    public Task<T> ExecuteTransactionalAsync<T>(Func<Task<T>> action, CancellationToken cancellationToken = default);
}
