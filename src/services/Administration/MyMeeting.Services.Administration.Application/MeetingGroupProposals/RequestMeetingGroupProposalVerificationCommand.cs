using BuildingBlocks.Abstractions.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Application.MeetingGroupProposals;

public class RequestMeetingGroupProposalVerificationCommand : ICommand<Guid>
{
    public RequestMeetingGroupProposalVerificationCommand(
            Guid id,
            Guid meetingGroupProposalId,
            string name,
            string description,
            string locationCity,
            string locationCountryCode,
            Guid proposalUserId,
            DateTime proposalDate)
    {
        this.MeetingGroupProposalId = meetingGroupProposalId;
        this.Name = name;
        this.Description = description;
        this.LocationCity = locationCity;
        this.LocationCountryCode = locationCountryCode;
        this.ProposalUserId = proposalUserId;
        this.ProposalDate = proposalDate;
    }

    public Guid MeetingGroupProposalId { get; }

    public string Name { get; }

    public string Description { get; }

    public string LocationCity { get; }

    public string LocationCountryCode { get; }

    public Guid ProposalUserId { get; }

    public DateTime ProposalDate { get; }
}
