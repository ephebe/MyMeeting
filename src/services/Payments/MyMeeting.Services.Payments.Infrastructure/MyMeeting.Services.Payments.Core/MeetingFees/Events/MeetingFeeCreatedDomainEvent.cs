using BuildingBlocks.Core.CQRS.Events.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Payments.Core.MeetingFees.Events;

public record MeetingFeeCreatedDomainEvent : DomainEvent
{
    public MeetingFeeCreatedDomainEvent(
            Guid meetingFeeId,
            Guid payerId,
            Guid meetingId,
            decimal feeValue,
            string feeCurrency,
            string status)
    {
        PayerId = payerId;
        MeetingId = meetingId;
        FeeValue = feeValue;
        FeeCurrency = feeCurrency;
        Status = status;
        MeetingFeeId = meetingFeeId;
    }

    public Guid MeetingFeeId { get; }

    public Guid PayerId { get; }

    public Guid MeetingId { get; }

    public decimal FeeValue { get; }

    public string FeeCurrency { get; }

    public string Status { get; }
}
