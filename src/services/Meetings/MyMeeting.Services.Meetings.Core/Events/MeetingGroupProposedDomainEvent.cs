using BuildingBlocks.Abstractions.CQRS.Events.Internal;
using BuildingBlocks.Core.CQRS.Events.Internal;
using MyMeeting.Services.Meetings.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Events;

public record MeetingGroupProposedDomainEvent : DomainEvent
{
    public MeetingGroupProposedDomainEvent(
        MeetingGroupProposalId meetingGroupProposalId,
        string name,
        string description,
        MemberId proposalUserId,
        DateTime proposalDate,
        string locationCity,
        string locationCountryCode)
    {
        this.MeetingGroupProposalId = meetingGroupProposalId;
        this.Name = name;
        this.Description = description;
        this.LocationCity = locationCity;
        this.LocationCountryCode = locationCountryCode;
        this.ProposalDate = proposalDate;
        this.ProposalUserId = proposalUserId;
    }

    public MeetingGroupProposalId MeetingGroupProposalId { get; }

    public string Name { get; }

    public string Description { get; }

    public string LocationCity { get; }

    public string LocationCountryCode { get; }

    public MemberId ProposalUserId { get; }

    public DateTime ProposalDate { get; }
}
