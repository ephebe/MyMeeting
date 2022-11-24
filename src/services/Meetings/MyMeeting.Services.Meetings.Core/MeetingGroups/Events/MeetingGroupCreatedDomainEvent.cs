using BuildingBlocks.Core.CQRS.Events.Internal;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingGroups.Events;

internal record MeetingGroupCreatedDomainEvent : DomainEvent
{
    public MeetingGroupId MeetingGroupId { get; }

    public MemberId CreatorId { get; }

    public MeetingGroupCreatedDomainEvent(MeetingGroupId meetingGroupId, MemberId creatorId)
    {
        this.MeetingGroupId = meetingGroupId;
        this.CreatorId = creatorId;
    }
}
