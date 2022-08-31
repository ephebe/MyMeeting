using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Core.Scheduler;

public class NullCommandScheduler : ICommandScheduler
{
    public Task ScheduleAsync(IInternalCommand command, CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }

    public Task ScheduleAsync(IInternalCommand[] commands, CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }

    public Task ScheduleAsync(IInternalCommand command, DateTimeOffset scheduleAt, string? description = null)
    {
        return Task.CompletedTask;
    }

    public Task ScheduleAsync(IInternalCommand[] commands, DateTimeOffset scheduleAt, string? description = null)
    {
        return Task.CompletedTask;
    }

    public Task ScheduleRecurringAsync(
        IInternalCommand command,
        string name,
        string cronExpression,
        string? description = null)
    {
        return Task.CompletedTask;
    }
}
