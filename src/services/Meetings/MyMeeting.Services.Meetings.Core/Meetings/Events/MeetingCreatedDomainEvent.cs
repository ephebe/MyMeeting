using BuildingBlocks.Core.CQRS.Events.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Events;

public record MeetingCreatedDomainEvent : DomainEvent
{
    public MeetingCreatedDomainEvent(MeetingId meetingId)
    {
        MeetingId = meetingId;
    }

    public MeetingId MeetingId { get; }
}
