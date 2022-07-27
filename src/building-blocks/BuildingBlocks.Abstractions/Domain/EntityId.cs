using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Abstractions.Domain;

public record EntityId : EntityId<Guid>
{
    public EntityId(Guid id) : base(id)
    {
    }

    public static implicit operator Guid(EntityId id) => Guard.Against.Null(id.Value, nameof(id.Value));
    public static implicit operator EntityId(Guid id) => new(id);
}

public record EntityId<T> : Identity<T>
{
    public EntityId(T id) : base(id)
    {
    }

    public static implicit operator T(EntityId<T> id) => Guard.Against.Null(id.Value, nameof(id.Value));
    public static implicit operator EntityId<T>(T id) => new(id);
}
