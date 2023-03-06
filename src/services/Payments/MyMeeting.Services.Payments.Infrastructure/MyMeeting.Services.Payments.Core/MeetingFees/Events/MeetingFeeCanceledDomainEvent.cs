using BuildingBlocks.Core.CQRS.Events.Internal;

namespace MyMeeting.Services.Payments.Core.MeetingFees.Events;

public record MeetingFeeCanceledDomainEvent : DomainEvent
{
    public MeetingFeeCanceledDomainEvent(Guid meetingFeeId, string status)
    {
        MeetingFeeId = meetingFeeId;
        Status = status;
    }

    public Guid MeetingFeeId { get; }

    public string Status { get; }
}
