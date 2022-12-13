using BuildingBlocks.Abstractions.Domain;
using MyMeeting.Services.Meetings.Core.MeetingGroups;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingComments.Rules;

public class CommentCanBeAddedOnlyByMeetingGroupMemberRule : IBusinessRule
{
    private readonly MemberId _authorId;
    private readonly MeetingGroup _meetingGroup;

    public CommentCanBeAddedOnlyByMeetingGroupMemberRule(MemberId authorId, MeetingGroup meetingGroup)
    {
        _authorId = authorId;
        _meetingGroup = meetingGroup;
    }

    public bool IsBroken() => !_meetingGroup.IsMemberOfGroup(_authorId);

    public string Message => "Only meeting attendee can add comments";
}
