using BuildingBlocks.Core.CQRS.Events.Internal;
using MyMeeting.Services.Meetings.Core.Meetings;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingGroups.Events;

public record MeetingAttendeeChangedDecisionDomainEvent : DomainEvent
{
    public MeetingAttendeeChangedDecisionDomainEvent(MemberId memberId, MeetingId meetingId)
    {
        MemberId = memberId;
        MeetingId = meetingId;
    }

    public MemberId MemberId { get; }

    public MeetingId MeetingId { get; }
}
