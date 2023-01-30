using BuildingBlocks.Core.CQRS.Events.Internal;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Events;

internal record MeetingNotAttendeeAddedDomainEvent : DomainEvent
{
    public MeetingId MeetingId { get; }

    public MemberId MemberId { get; }

    public MeetingNotAttendeeAddedDomainEvent(MeetingId meetingId, MemberId memberId)
    {
        MeetingId = meetingId;
        MemberId = memberId;
    }
}
