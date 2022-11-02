using Ardalis.GuardClauses;
using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Core.Users;

public record UserId : AggregateId
{
    public UserId(Guid value)
            : base(value)
    {
        Guard.Against.Null(value, nameof(value));
    }

    public static implicit operator Guid(UserId id) => id.Value;

    public static implicit operator UserId(Guid id) => new(id);
}
