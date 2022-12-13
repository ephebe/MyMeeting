using BuildingBlocks.Abstractions.Domain;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Rules;

public class MemberCannotBeNotAttendeeTwiceRule : IBusinessRule
{
    private readonly List<MeetingNotAttendee> _notAttendees;

    private readonly MemberId _memberId;

    public MemberCannotBeNotAttendeeTwiceRule(List<MeetingNotAttendee> notAttendees, MemberId memberId)
    {
        _notAttendees = notAttendees;
        _memberId = memberId;
    }

    public bool IsBroken() => _notAttendees.SingleOrDefault(x => x.IsActiveNotAttendee(_memberId)) != null;

    public string Message => "Member cannot be active not attendee twice";
}
