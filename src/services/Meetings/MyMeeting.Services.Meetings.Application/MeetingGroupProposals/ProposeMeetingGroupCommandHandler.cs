using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.Persistence;
using MyMeeting.Services.Meetings.Core;
using MyMeeting.Services.Meetings.Core.MeetingGroupProposals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Application.MeetingGroupProposals;

internal class ProposeMeetingGroupCommandHandler : ICommandHandler<ProposeMeetingGroupCommand, Guid>
{
    private readonly IRepository<MeetingGroupProposal, MeetingGroupProposalId> _meetingGroupProposalRepository;
    private readonly IMemberContext _memberContext;
    internal ProposeMeetingGroupCommandHandler(
            IRepository<MeetingGroupProposal, MeetingGroupProposalId> meetingGroupProposalRepository,
            IMemberContext memberContext)
    {
        _meetingGroupProposalRepository = meetingGroupProposalRepository;
        _memberContext = memberContext;
    }

    public async Task<Guid> Handle(ProposeMeetingGroupCommand request, CancellationToken cancellationToken)
    {
        var meetingGroupProposal = MeetingGroupProposal.ProposeNew(
                request.Name,
                request.Description,
                MeetingGroupLocation.CreateNew(request.LocationCity, request.LocationCountryCode),
                _memberContext.MemberId);

        await _meetingGroupProposalRepository.AddAsync(meetingGroupProposal);

        return meetingGroupProposal.Id.Value;
    }
}
