using BuildingBlocks.Core.CQRS.Events.Internal;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Events;

internal record MemberSetAsAttendeeDomainEvent : DomainEvent
{
    public MemberSetAsAttendeeDomainEvent(MeetingId meetingId, MemberId hostId)
    {
        MeetingId = meetingId;
        HostId = hostId;
    }

    public MeetingId MeetingId { get; }

    public MemberId HostId { get; }
}
