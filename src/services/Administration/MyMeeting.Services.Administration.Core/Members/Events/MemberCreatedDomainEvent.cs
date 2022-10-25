using BuildingBlocks.Core.CQRS.Events.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Core.Members.Events;

public record MemberCreatedDomainEvent : DomainEvent
{
    public MemberCreatedDomainEvent(MemberId memberId)
    {
        MemberId = memberId;
    }

    public MemberId MemberId { get; }
}
