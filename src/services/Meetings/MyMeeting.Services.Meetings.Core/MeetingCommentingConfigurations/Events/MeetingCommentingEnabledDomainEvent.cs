using BuildingBlocks.Core.CQRS.Events.Internal;
using MyMeeting.Services.Meetings.Core.Meetings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingCommentingConfigurations.Events;

public record MeetingCommentingEnabledDomainEvent : DomainEvent
{
    public MeetingId MeetingId { get; }

    public MeetingCommentingEnabledDomainEvent(MeetingId meetingId)
    {
        MeetingId = meetingId;
    }
}
