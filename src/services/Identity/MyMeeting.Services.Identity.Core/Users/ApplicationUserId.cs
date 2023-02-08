using Ardalis.GuardClauses;
using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Core.Users;

public record ApplicationUserId : AggregateId
{
    public ApplicationUserId(Guid value) : base(value)
    {
        Guard.Against.NullOrEmpty(value, nameof(value));
    }

    public static implicit operator Guid(ApplicationUserId id) => id.Value;

    public static implicit operator ApplicationUserId(Guid id) => new(id);
}
