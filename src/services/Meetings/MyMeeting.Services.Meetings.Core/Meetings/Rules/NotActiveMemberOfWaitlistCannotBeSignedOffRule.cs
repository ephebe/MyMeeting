using BuildingBlocks.Abstractions.Domain;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Rules;

public class NotActiveMemberOfWaitlistCannotBeSignedOffRule : IBusinessRule
{
    private readonly List<MeetingWaitlistMember> _waitlistMembers;

    private readonly MemberId _memberId;

    public NotActiveMemberOfWaitlistCannotBeSignedOffRule(List<MeetingWaitlistMember> waitlistMembers, MemberId memberId)
    {
        _waitlistMembers = waitlistMembers;
        _memberId = memberId;
    }

    public bool IsBroken() => _waitlistMembers.SingleOrDefault(x => x.IsActiveOnWaitList(_memberId)) == null;

    public string Message => "Not active member of waitlist cannot be signed off";
}
