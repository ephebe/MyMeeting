using BuildingBlocks.Core.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Shared.Meetings.IntegrationEvents;

public record MeetingAttendeeAddedIntegrationEvent : IntegrationEvent
{
    public Guid MeetingId { get; }

    public Guid AttendeeId { get; }

    public decimal? FeeValue { get; }

    public string FeeCurrency { get; }

    public MeetingAttendeeAddedIntegrationEvent(
        DateTime occurredOn,
        Guid meetingId,
        Guid attendeeId,
        decimal? feeValue,
        string feeCurrency)
    {
        MeetingId = meetingId;
        AttendeeId = attendeeId;
        FeeValue = feeValue;
        FeeCurrency = feeCurrency;
    }
}
