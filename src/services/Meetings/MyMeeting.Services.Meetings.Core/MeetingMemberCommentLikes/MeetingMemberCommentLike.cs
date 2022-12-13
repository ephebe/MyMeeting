using BuildingBlocks.Core.Domain;
using MyMeeting.Services.Meetings.Core.MeetingComments;
using MyMeeting.Services.Meetings.Core.MeetingMemberCommentLikes.Events;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingMemberCommentLikes;

public class MeetingMemberCommentLike : Aggregate<MeetingMemberCommentLikeId>
{
    private MeetingCommentId _meetingCommentId;

    private MemberId _memberId;

    private MeetingMemberCommentLike()
    {
        // Only for EF.
    }

    private MeetingMemberCommentLike(MeetingCommentId meetingCommentId, MemberId memberId)
    {
        Id = new MeetingMemberCommentLikeId(Guid.NewGuid());
        _meetingCommentId = meetingCommentId;
        _memberId = memberId;

        this.AddDomainEvents(new MeetingCommentLikedDomainEvent(meetingCommentId, memberId));
    }

    public void Remove()
    {
        this.AddDomainEvents(new MeetingCommentUnlikedDomainEvent(_meetingCommentId, _memberId));
    }

    public static MeetingMemberCommentLike Create(MeetingCommentId meetingCommentId, MemberId memberId)
        => new MeetingMemberCommentLike(meetingCommentId, memberId);
}