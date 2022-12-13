using BuildingBlocks.Abstractions.Domain;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Rules;

public class MemberCannotBeMoreThanOnceOnMeetingWaitlistRule : IBusinessRule
{
    private readonly List<MeetingWaitlistMember> _waitListMembers;

    private readonly MemberId _memberId;

    internal MemberCannotBeMoreThanOnceOnMeetingWaitlistRule(List<MeetingWaitlistMember> waitListMembers, MemberId memberId)
    {
        _waitListMembers = waitListMembers;
        _memberId = memberId;
    }

    public bool IsBroken() => _waitListMembers.SingleOrDefault(x => x.IsActiveOnWaitList(_memberId)) != null;

    public string Message => "Member cannot be more than once on the meeting waitlist";
}
