using BuildingBlocks.Abstractions.CQRS.Commands;
using MyMeeting.Services.Meetings.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Application.Commands.Handlers;

internal class ProposeMeetingGroupCommandHandler : ICommandHandler<ProposeMeetingGroupCommand, Guid>
{
    private readonly IMeetingGroupProposalRepository _meetingGroupProposalRepository;
    private readonly IMemberContext _memberContext;
    internal ProposeMeetingGroupCommandHandler(
            IMeetingGroupProposalRepository meetingGroupProposalRepository,
            IMemberContext memberContext)
    {
        _meetingGroupProposalRepository = meetingGroupProposalRepository;
        _memberContext = memberContext;
    }

    public Task<Guid> Handle(ProposeMeetingGroupCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
