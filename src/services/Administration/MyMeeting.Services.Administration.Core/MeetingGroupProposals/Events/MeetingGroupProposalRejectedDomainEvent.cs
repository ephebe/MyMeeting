using BuildingBlocks.Core.CQRS.Events.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Core.MeetingGroupProposals.Events;

public record MeetingGroupProposalRejectedDomainEvent : DomainEvent
{
    internal MeetingGroupProposalRejectedDomainEvent(MeetingGroupProposalId meetingGroupProposalId)
    {
        MeetingGroupProposalId = meetingGroupProposalId;
    }

    internal MeetingGroupProposalId MeetingGroupProposalId { get; }
}
