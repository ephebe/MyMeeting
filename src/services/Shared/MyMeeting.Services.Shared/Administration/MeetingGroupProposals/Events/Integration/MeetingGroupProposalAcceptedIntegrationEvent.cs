using BuildingBlocks.Core.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Shared.Administration.MeetingGroupProposals.Events.Integration;

public record MeetingGroupProposalAcceptedIntegrationEvent : IntegrationEvent
{
    public Guid MeetingGroupProposalId { get; set; }
}
