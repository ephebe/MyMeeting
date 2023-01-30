using BuildingBlocks.Abstractions.Domain;
using BuildingBlocks.Core.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Core.Domain;

public abstract class Entity<TId> : IEntity<TId>
{
    protected Entity(TId id) => Id = id;
    protected Entity() { }

    public TId Id { get; protected set; }

    public DateTime Created { get; protected set; }
    public Guid? CreatedBy { get; protected set; }

    public void CheckRule(IBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }
}

public abstract class Entity<TIdentity, TId> : Entity<TIdentity>
    where TIdentity : Identity<TId>
{
}

public abstract class Entity : Entity<EntityId, Guid>, IEntity
{
}
