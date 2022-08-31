using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Abstractions.CQRS.Commands;
/// <summary>
/// 第一個方法只是對MediatR.Send簡單包覆，其他的則是把Command存入DB中
/// </summary>
public interface ICommandProcessor
{
    Task<TResult> SendAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default)
        where TResult : notnull;

    Task ScheduleAsync(IInternalCommand internalCommandCommand, CancellationToken cancellationToken = default);
    Task ScheduleAsync(IInternalCommand[] internalCommandCommands, CancellationToken cancellationToken = default);
}
