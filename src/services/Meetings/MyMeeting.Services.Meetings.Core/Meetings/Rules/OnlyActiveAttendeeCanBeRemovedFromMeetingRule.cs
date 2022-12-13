using BuildingBlocks.Abstractions.Domain;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Rules;

public class OnlyActiveAttendeeCanBeRemovedFromMeetingRule : IBusinessRule
{
    private readonly List<MeetingAttendee> _attendees;
    private readonly MemberId _attendeeId;

    internal OnlyActiveAttendeeCanBeRemovedFromMeetingRule(
        List<MeetingAttendee> attendees,
        MemberId attendeeId)
    {
        _attendees = attendees;
        _attendeeId = attendeeId;
    }

    public bool IsBroken() => _attendees.SingleOrDefault(x => x.IsActiveAttendee(_attendeeId)) == null;

    public string Message => "Only active attendee can be removed from meeting";
}
