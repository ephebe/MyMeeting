using BuildingBlocks.Core.CQRS.Events.Internal;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Events;

public record MeetingAttendeeAddedDomainEvent : DomainEvent
{
    public MeetingAttendeeAddedDomainEvent(
            MeetingId meetingId,
            MemberId attendeeId,
            DateTime rsvpDate,
            string role,
            int guestsNumber,
            decimal? feeValue,
            string feeCurrency)
    {
        MeetingId = meetingId;
        AttendeeId = attendeeId;
        RSVPDate = rsvpDate;
        Role = role;
        GuestsNumber = guestsNumber;
        FeeValue = feeValue;
        FeeCurrency = feeCurrency;
    }

    public MeetingId MeetingId { get; }

    public MemberId AttendeeId { get; }

    public DateTime RSVPDate { get; }

    public string Role { get; }

    public int GuestsNumber { get; }

    public decimal? FeeValue { get; }

    public string FeeCurrency { get; }
}
