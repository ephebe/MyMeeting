using BuildingBlocks.Core.Domain;
using BuildingBlocks.Core.Utils;
using MyMeeting.Services.Meetings.Core.MeetingCommentingConfigurations;
using MyMeeting.Services.Meetings.Core.MeetingComments.Events;
using MyMeeting.Services.Meetings.Core.MeetingComments.Rules;
using MyMeeting.Services.Meetings.Core.MeetingGroups;
using MyMeeting.Services.Meetings.Core.MeetingMemberCommentLikes;
using MyMeeting.Services.Meetings.Core.Meetings;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingComments;

public class MeetingComment : Aggregate<MeetingCommentId>
{
    private MeetingId _meetingId;

    private MemberId _authorId;

    private MeetingCommentId? _inReplyToCommentId;

    private string _comment;

    private DateTime _createDate;

    private DateTime? _editDate;

    private bool _isRemoved;

    private string _removedByReason;

    private MeetingComment(
        MeetingId meetingId,
        MemberId authorId,
        string comment,
        MeetingCommentId? inReplyToCommentId,
        MeetingCommentingConfiguration meetingCommentingConfiguration,
        MeetingGroup meetingGroup)
    {
        this.CheckRule(new CommentTextMustBeProvidedRule(comment));
        this.CheckRule(new CommentCanBeCreatedOnlyIfCommentingForMeetingEnabledRule(meetingCommentingConfiguration));
        this.CheckRule(new CommentCanBeAddedOnlyByMeetingGroupMemberRule(authorId, meetingGroup));

        this.Id = new MeetingCommentId(Guid.NewGuid());
        _meetingId = meetingId;
        _authorId = authorId;
        _comment = comment;

        _inReplyToCommentId = inReplyToCommentId;

        _createDate = SystemClock.Now;
        _editDate = null;

        _isRemoved = false;
        _removedByReason = null;

        if (inReplyToCommentId == null)
        {
            this.AddDomainEvents(new MeetingCommentAddedDomainEvent(this.Id, _meetingId, comment));
        }
        else
        {
            this.AddDomainEvents(new ReplyToMeetingCommentAddedDomainEvent(this.Id, inReplyToCommentId, comment));
        }
    }

    private MeetingComment()
    {
        // Only for EF.
    }

    public void Edit(MemberId editorId, string editedComment, MeetingCommentingConfiguration meetingCommentingConfiguration)
    {
        this.CheckRule(new CommentTextMustBeProvidedRule(editedComment));
        this.CheckRule(new MeetingCommentCanBeEditedOnlyByAuthorRule(this._authorId, editorId));
        this.CheckRule(new CommentCanBeEditedOnlyIfCommentingForMeetingEnabledRule(meetingCommentingConfiguration));

        _comment = editedComment;
        _editDate = SystemClock.Now;

        this.AddDomainEvents(new MeetingCommentEditedDomainEvent(this.Id, editedComment));
    }

    public void Remove(MemberId removingMemberId, MeetingGroup meetingGroup, string reason = null)
    {
        this.CheckRule(new MeetingCommentCanBeRemovedOnlyByAuthorOrGroupOrganizerRule(meetingGroup, this._authorId, removingMemberId));
        this.CheckRule(new RemovingReasonCanBeProvidedOnlyByGroupOrganizerRule(meetingGroup, removingMemberId, reason));

        _isRemoved = true;
        _removedByReason = reason ?? string.Empty;

        this.AddDomainEvents(new MeetingCommentRemovedDomainEvent(this.Id));
    }

    public MeetingComment Reply(MemberId replierId, string reply, MeetingGroup meetingGroup, MeetingCommentingConfiguration meetingCommentingConfiguration)
        => new MeetingComment(
            _meetingId,
            replierId,
            reply,
            this.Id,
            meetingCommentingConfiguration,
            meetingGroup);

    public MeetingMemberCommentLike Like(
        MemberId likerId,
        MeetingGroupMemberData likerMeetingGroupMember,
        int meetingMemberCommentLikesCount)
    {
        this.CheckRule(new CommentCanBeLikedOnlyByMeetingGroupMemberRule(likerMeetingGroupMember));
        this.CheckRule(new CommentCannotBeLikedByTheSameMemberMoreThanOnceRule(meetingMemberCommentLikesCount));

        return MeetingMemberCommentLike.Create(this.Id, likerId);
    }

    public MeetingId GetMeetingId() => this._meetingId;

    internal static MeetingComment Create(
        MeetingId meetingId,
        MemberId authorId,
        string comment,
        MeetingGroup meetingGroup,
        MeetingCommentingConfiguration meetingCommentingConfiguration)
        => new MeetingComment(
            meetingId,
            authorId,
            comment,
            inReplyToCommentId: null,
            meetingCommentingConfiguration,
            meetingGroup);
}
