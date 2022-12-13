using BuildingBlocks.Abstractions.Domain;
using MyMeeting.Services.Meetings.Core.MeetingGroups;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Rules;

public class MemberOnWaitlistMustBeAMemberOfGroupRule : IBusinessRule
{
    private readonly MeetingGroup _meetingGroup;

    private readonly MemberId _memberId;

    private readonly List<MeetingAttendee> _attendees;

    internal MemberOnWaitlistMustBeAMemberOfGroupRule(MeetingGroup meetingGroup, MemberId memberId, List<MeetingAttendee> attendees)
    {
        _meetingGroup = meetingGroup;
        _memberId = memberId;
        _attendees = attendees;
    }

    public bool IsBroken() => !_meetingGroup.IsMemberOfGroup(_memberId);

    public string Message => "Member on waitlist must be a member of group";
}
