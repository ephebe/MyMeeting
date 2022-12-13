using BuildingBlocks.Core.CQRS.Events.Internal;
using MyMeeting.Services.Meetings.Core.MeetingComments;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingMemberCommentLikes.Events;

public record MeetingCommentLikedDomainEvent : DomainEvent
{
    public MeetingCommentId MeetingCommentId { get; }

    public MemberId LikerId { get; }

    public MeetingCommentLikedDomainEvent(MeetingCommentId meetingCommentId, MemberId likerId)
    {
        MeetingCommentId = meetingCommentId;
        LikerId = likerId;
    }
}
