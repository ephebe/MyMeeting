using BuildingBlocks.Abstractions.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Abstractions.Scheduler;

/// <summary>
/// 原作還沒實作出來，不知意義為何
/// </summary>
public interface ICommandScheduler
{
    Task ScheduleAsync(IInternalCommand command, CancellationToken cancellationToken = default);
    Task ScheduleAsync(IInternalCommand[] commands, CancellationToken cancellationToken = default);
    Task ScheduleAsync(IInternalCommand command, DateTimeOffset scheduleAt, string? description = null);
    Task ScheduleAsync(IInternalCommand[] commands, DateTimeOffset scheduleAt, string? description = null);
    Task ScheduleRecurringAsync(
        IInternalCommand command,
        string name,
        string cronExpression,
        string? description = null);
}
