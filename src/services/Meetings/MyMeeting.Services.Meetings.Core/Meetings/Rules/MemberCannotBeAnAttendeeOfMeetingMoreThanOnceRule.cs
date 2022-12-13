using BuildingBlocks.Abstractions.Domain;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Rules;

public class MemberCannotBeAnAttendeeOfMeetingMoreThanOnceRule : IBusinessRule
{
    private readonly MemberId _attendeeId;

    private readonly List<MeetingAttendee> _attendees;

    public MemberCannotBeAnAttendeeOfMeetingMoreThanOnceRule(MemberId attendeeId, List<MeetingAttendee> attendees)
    {
        this._attendeeId = attendeeId;
        _attendees = attendees;
    }

    public bool IsBroken() => _attendees.SingleOrDefault(x => x.IsActiveAttendee(_attendeeId)) != null;

    public string Message => "Member is already an attendee of this meeting";
}
