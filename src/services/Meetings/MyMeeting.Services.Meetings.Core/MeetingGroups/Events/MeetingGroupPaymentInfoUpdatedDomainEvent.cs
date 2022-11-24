using BuildingBlocks.Core.CQRS.Events.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingGroups.Events;

public record MeetingGroupPaymentInfoUpdatedDomainEvent : DomainEvent
{
    public MeetingGroupPaymentInfoUpdatedDomainEvent(MeetingGroupId meetingGroupId, DateTime paymentDateTo)
    {
        MeetingGroupId = meetingGroupId;
        PaymentDateTo = paymentDateTo;
    }

    public MeetingGroupId MeetingGroupId { get; }

    public DateTime PaymentDateTo { get; }
}
