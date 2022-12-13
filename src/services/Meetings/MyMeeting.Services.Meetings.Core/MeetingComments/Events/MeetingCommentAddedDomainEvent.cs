using BuildingBlocks.Core.CQRS.Events.Internal;
using MyMeeting.Services.Meetings.Core.Meetings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingComments.Events;

public record MeetingCommentAddedDomainEvent : DomainEvent
{
    public MeetingCommentId MeetingCommentId { get; }

    public MeetingId MeetingId { get; }

    public string Comment { get; }

    public MeetingCommentAddedDomainEvent(MeetingCommentId meetingCommentId, MeetingId meetingId, string comment)
    {
        MeetingCommentId = meetingCommentId;
        MeetingId = meetingId;
        Comment = comment;
    }
}
