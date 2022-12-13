using BuildingBlocks.Core.CQRS.Events.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingComments.Events;

public record MeetingCommentRemovedDomainEvent : DomainEvent
{
    public MeetingCommentId MeetingCommentId { get; }

    public MeetingCommentRemovedDomainEvent(MeetingCommentId meetingCommentId)
    {
        MeetingCommentId = meetingCommentId;
    }
}
