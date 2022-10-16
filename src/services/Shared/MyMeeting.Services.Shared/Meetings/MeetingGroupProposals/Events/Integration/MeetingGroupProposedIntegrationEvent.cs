using BuildingBlocks.Core.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Shared.Meetings.MeetingGroupProposals.Events.Integration;

public record MeetingGroupProposedIntegrationEvent : IntegrationEvent
{
    public Guid MeetingGroupProposalId { get; }

    public string Name { get; }

    public string Description { get; }

    public string LocationCity { get; }

    public string LocationCountryCode { get; }

    public Guid ProposalUserId { get; }

    public DateTime ProposalDate { get; }
}
