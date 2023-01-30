using Ardalis.GuardClauses;
using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.UserAccess.Core.UserRegistrations;

public record UserRegistrationId : AggregateId
{
    public UserRegistrationId(Guid value) : base(value)
    {
        Guard.Against.Null(value, nameof(value));
    }

    public static implicit operator Guid(UserRegistrationId id) => id.Value;

    public static implicit operator UserRegistrationId(Guid id) => new(id);
}
