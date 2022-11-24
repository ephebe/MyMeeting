using BuildingBlocks.Core.CQRS.Events.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingGroups.Events;

public record MeetingGroupGeneralAttributesEditedDomainEvent : DomainEvent
{
    public string NewName { get; }

    public string NewDescription { get; }

    public MeetingGroupLocation NewLocation { get; }

    public MeetingGroupGeneralAttributesEditedDomainEvent(string newName, string newDescription, MeetingGroupLocation newLocation)
    {
        this.NewName = newName;
        this.NewDescription = newDescription;
        this.NewLocation = newLocation;
    }
}
