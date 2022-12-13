using BuildingBlocks.Core.CQRS.Events.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingComments.Events;

public record ReplyToMeetingCommentAddedDomainEvent : DomainEvent
{
    public MeetingCommentId MeetingCommentId { get; }

    public MeetingCommentId InReplyToCommentId { get; }

    public string Reply { get; }

    public ReplyToMeetingCommentAddedDomainEvent(MeetingCommentId meetingCommentId, MeetingCommentId inReplyToCommentId, string reply)
    {
        MeetingCommentId = meetingCommentId;
        InReplyToCommentId = inReplyToCommentId;
        Reply = reply;
    }
}
