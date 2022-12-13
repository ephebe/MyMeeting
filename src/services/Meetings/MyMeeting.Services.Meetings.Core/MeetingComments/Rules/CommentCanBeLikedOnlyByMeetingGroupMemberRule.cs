using BuildingBlocks.Abstractions.Domain;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingComments.Rules;

public class CommentCanBeLikedOnlyByMeetingGroupMemberRule : IBusinessRule
{
    private readonly MeetingGroupMemberData _likerMeetingGroupMember;

    public CommentCanBeLikedOnlyByMeetingGroupMemberRule(MeetingGroupMemberData? likerMeetingGroupMember)
    {
        _likerMeetingGroupMember = likerMeetingGroupMember;
    }

    public bool IsBroken() => _likerMeetingGroupMember == null;

    public string Message => "Comment can be liked only by meeting group member.";
}
