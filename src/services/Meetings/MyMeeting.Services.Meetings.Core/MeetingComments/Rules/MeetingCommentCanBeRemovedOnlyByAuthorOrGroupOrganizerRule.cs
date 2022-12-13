using BuildingBlocks.Abstractions.Domain;
using MyMeeting.Services.Meetings.Core.MeetingGroups;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingComments.Rules;

public class MeetingCommentCanBeRemovedOnlyByAuthorOrGroupOrganizerRule : IBusinessRule
{
    private readonly MeetingGroup _meetingGroup;
    private readonly MemberId _authorId;
    private readonly MemberId _removingMemberId;

    public MeetingCommentCanBeRemovedOnlyByAuthorOrGroupOrganizerRule(MeetingGroup meetingGroup, MemberId authorId, MemberId removingMemberId)
    {
        _meetingGroup = meetingGroup;
        _authorId = authorId;
        _removingMemberId = removingMemberId;
    }

    public bool IsBroken() => _removingMemberId != _authorId && !_meetingGroup.IsOrganizer(_removingMemberId);

    public string Message => "Only author of comment or group organizer can remove meeting comment.";
}
