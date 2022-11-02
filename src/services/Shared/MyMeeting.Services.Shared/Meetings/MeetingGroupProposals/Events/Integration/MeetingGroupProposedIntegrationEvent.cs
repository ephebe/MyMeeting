using BuildingBlocks.Core.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Shared.Meetings.MeetingGroupProposals.Events.Integration;

public record MeetingGroupProposedIntegrationEvent : IntegrationEvent
{
    public Guid MeetingGroupProposalId { 
        get; 
        set; 
    }

    public string Name { get; set; }

    public string Description { get; set; }

    public string LocationCity { get; set; }

    public string LocationCountryCode { get; set; }

    public Guid ProposalUserId { get; set; }

    public DateTime ProposalDate { get; set; }
}
