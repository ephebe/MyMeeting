using BuildingBlocks.Core.CQRS.Events.Internal;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingGroups.Events;

public record NewMeetingGroupMemberJoinedDomainEvent : DomainEvent
{
    public MeetingGroupId MeetingGroupId { get; }

    public MemberId MemberId { get; }

    public MeetingGroupMemberRole Role { get; }

    public NewMeetingGroupMemberJoinedDomainEvent(MeetingGroupId meetingGroupId, MemberId memberId, MeetingGroupMemberRole role)
    {
        this.MeetingGroupId = meetingGroupId;
        this.MemberId = memberId;
        this.Role = role;
    }
}
