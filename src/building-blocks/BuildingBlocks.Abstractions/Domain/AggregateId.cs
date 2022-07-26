﻿using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Abstractions.Domain;

public record AggregateId<T> : Identity<T>
{
    public AggregateId(T value) : base(value)
    {
    }

    public static implicit operator T(AggregateId<T> id) => Guard.Against.Null(id.Value, nameof(id.Value));
    public static implicit operator AggregateId<T>(T id) => new(id);
}

public record AggregateId : AggregateId<Guid>
{
    public AggregateId(Guid value) : base(value)
    {
        Guard.Against.Null(value, nameof(value));
    }

    public static implicit operator Guid(AggregateId id) => Guard.Against.Null(id.Value, nameof(id.Value));
    public static implicit operator AggregateId(Guid id) => new(id);
}
