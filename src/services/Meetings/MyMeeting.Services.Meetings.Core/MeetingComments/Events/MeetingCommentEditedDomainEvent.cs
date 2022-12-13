using BuildingBlocks.Core.CQRS.Events.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingComments.Events;

public record MeetingCommentEditedDomainEvent : DomainEvent
{
    public MeetingCommentId MeetingCommentId { get; }

    public string EditedComment { get; }

    public MeetingCommentEditedDomainEvent(MeetingCommentId meetingCommentId, string editedComment)
    {
        MeetingCommentId = meetingCommentId;
        EditedComment = editedComment;
    }
}
