using BuildingBlocks.Abstractions.CQRS.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Application.MeetingGroupProposals.AcceptMeetingGroupProposal;

public class AcceptMeetingGroupProposalCommand : ICommand<Unit>
{
    public Guid MeetingGroupProposalId { get; }

    public AcceptMeetingGroupProposalCommand(Guid meetingGroupProposalId)
    {
        MeetingGroupProposalId = meetingGroupProposalId;
    }
}
