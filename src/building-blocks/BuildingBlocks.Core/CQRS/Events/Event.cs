﻿using BuildingBlocks.Abstractions.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Core.CQRS.Events;

public abstract record Event : IEvent
{
    public Guid EventId { get; protected set; } = Guid.NewGuid();

    public long EventVersion { get; protected set; } = -1;

    public DateTime OccurredOn { get; protected set; } = DateTime.Now;

    public DateTimeOffset TimeStamp { get; protected set; } = DateTimeOffset.Now;

    public string EventType => TypeMapper.GetTypeName(GetType());
}
