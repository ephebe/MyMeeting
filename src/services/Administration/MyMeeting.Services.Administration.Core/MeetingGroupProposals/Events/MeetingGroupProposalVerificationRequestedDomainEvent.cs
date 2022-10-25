using BuildingBlocks.Core.CQRS.Events.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Core.MeetingGroupProposals.Events;

public record MeetingGroupProposalVerificationRequestedDomainEvent : DomainEvent
{
    internal MeetingGroupProposalVerificationRequestedDomainEvent(MeetingGroupProposalId meetingGroupProposalId)
    {
        MeetingGroupProposalId = meetingGroupProposalId;
    }

    public MeetingGroupProposalId MeetingGroupProposalId { get; }
}
