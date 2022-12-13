using BuildingBlocks.Core.CQRS.Events.Internal;
using MyMeeting.Services.Meetings.Core.Meetings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingCommentingConfigurations.Events;

public record MeetingCommentingConfigurationCreatedDomainEvent : DomainEvent
{
    public MeetingId MeetingId { get; }

    public bool IsEnabled { get; }

    public MeetingCommentingConfigurationCreatedDomainEvent(MeetingId meetingId, bool isEnabled)
    {
        MeetingId = meetingId;
        IsEnabled = isEnabled;
    }
}
