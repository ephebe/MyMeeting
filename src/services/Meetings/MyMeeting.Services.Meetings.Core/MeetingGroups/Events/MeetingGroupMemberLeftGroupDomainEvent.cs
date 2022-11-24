using BuildingBlocks.Core.CQRS.Events.Internal;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingGroups.Events;

public record MeetingGroupMemberLeftGroupDomainEvent : DomainEvent
{
    public MeetingGroupMemberLeftGroupDomainEvent(MeetingGroupId meetingGroupId, MemberId memberId)
    {
        MeetingGroupId = meetingGroupId;
        MemberId = memberId;
    }

    public MeetingGroupId MeetingGroupId { get; }

    public MemberId MemberId { get; }
}
