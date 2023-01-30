using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Rules;

internal class MemberCannotHaveSetAttendeeRoleMoreThanOnceRule : IBusinessRule
{
    private readonly MeetingAttendeeRole _meetingAttendeeRole;

    internal MemberCannotHaveSetAttendeeRoleMoreThanOnceRule(MeetingAttendeeRole meetingAttendeeRole)
    {
        _meetingAttendeeRole = meetingAttendeeRole;
    }

    public bool IsBroken() => _meetingAttendeeRole == MeetingAttendeeRole.Attendee;

    public string Message => "Member cannot be attendee of meeting more than once";
}
