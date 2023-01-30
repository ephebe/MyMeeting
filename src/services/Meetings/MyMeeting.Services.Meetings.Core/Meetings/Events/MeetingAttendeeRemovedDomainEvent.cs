using BuildingBlocks.Core.CQRS.Events.Internal;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Events;

public record MeetingAttendeeRemovedDomainEvent : DomainEvent
{
    public MeetingAttendeeRemovedDomainEvent(MemberId memberId, MeetingId meetingId, string reason)
    {
        MemberId = memberId;
        MeetingId = meetingId;
        Reason = reason;
    }

    public MemberId MemberId { get; }

    public MeetingId MeetingId { get; }

    public string Reason { get; }
}
