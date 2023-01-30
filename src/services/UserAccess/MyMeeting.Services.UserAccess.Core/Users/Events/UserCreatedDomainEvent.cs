using BuildingBlocks.Core.CQRS.Events.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.UserAccess.Core.Users.Events;

public record UserCreatedDomainEvent : DomainEvent
{
    public UserCreatedDomainEvent(UserId id)
    {
        Id = id;
    }

    public new UserId Id { get; }
}
