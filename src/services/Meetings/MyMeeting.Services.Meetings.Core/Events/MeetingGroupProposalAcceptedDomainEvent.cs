using BuildingBlocks.Core.CQRS.Events.Internal;
using MyMeeting.Services.Meetings.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Events;

public record MeetingGroupProposalAcceptedDomainEvent : DomainEvent
{
    public MeetingGroupProposalId MeetingGroupProposalId { get; }

    public MeetingGroupProposalAcceptedDomainEvent(MeetingGroupProposalId meetingGroupProposalId)
    {
        MeetingGroupProposalId = meetingGroupProposalId;
    }
}
