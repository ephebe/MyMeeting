using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Abstractions.CQRS.Queries;

/// <summary>
/// 第一個Send只是對MediatR.Send的簡單包覆，第一個Send待查
/// </summary>
public interface IQueryProcessor
{
    Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
        where TResponse : notnull;

    IAsyncEnumerable<TResponse> SendAsync<TResponse>(
        IStreamQuery<TResponse> query,
        CancellationToken cancellationToken = default)
        where TResponse : notnull;
}
