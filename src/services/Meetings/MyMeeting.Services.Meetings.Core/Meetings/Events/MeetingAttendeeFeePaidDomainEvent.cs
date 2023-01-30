using BuildingBlocks.Core.CQRS.Events.Internal;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Events;

internal record MeetingAttendeeFeePaidDomainEvent : DomainEvent
{
    public MeetingAttendeeFeePaidDomainEvent(MeetingId meetingId, MemberId attendeeId)
    {
        MeetingId = meetingId;
        AttendeeId = attendeeId;
    }

    public MeetingId MeetingId { get; }

    public MemberId AttendeeId { get; }
}
