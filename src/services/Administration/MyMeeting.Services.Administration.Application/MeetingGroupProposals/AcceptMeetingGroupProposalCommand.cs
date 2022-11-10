using BuildingBlocks.Abstractions.CQRS.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Application.MeetingGroupProposals;

public class AcceptMeetingGroupProposalCommand : ICommand<Unit>
{
    public AcceptMeetingGroupProposalCommand(Guid meetingGroupProposalId)
    {
        MeetingGroupProposalId = meetingGroupProposalId;
    }

    internal Guid MeetingGroupProposalId { get; }
}
