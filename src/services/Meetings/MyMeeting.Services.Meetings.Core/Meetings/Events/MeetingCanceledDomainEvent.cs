using BuildingBlocks.Core.CQRS.Events.Internal;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Events;

public record MeetingCanceledDomainEvent : DomainEvent
{
    public MeetingCanceledDomainEvent(MeetingId meetingId, MemberId cancelMemberId, DateTime cancelDate)
    {
        MeetingId = meetingId;
        CancelMemberId = cancelMemberId;
        CancelDate = cancelDate;
    }

    public MeetingId MeetingId { get; }

    public MemberId CancelMemberId { get; }

    public DateTime CancelDate { get; }
}
