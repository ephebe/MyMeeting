using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.Persistence;
using MyMeeting.Services.Meetings.Core.MeetingGroupProposals;
using MyMeeting.Services.Meetings.Core.MeetingGroups;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Application.MeetingGroupProposals.ProposeMeetingGroup;

public class ProposeMeetingGroupCommandHandler : ICommandHandler<ProposeMeetingGroupCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<MeetingGroupProposal, MeetingGroupProposalId> _meetingGroupProposalRepository;
    private readonly IMemberContext _memberContext;
    public ProposeMeetingGroupCommandHandler(
            IUnitOfWork unitOfWork,
            IRepository<MeetingGroupProposal, MeetingGroupProposalId> meetingGroupProposalRepository,
            IMemberContext memberContext)
    {
        _unitOfWork = unitOfWork;
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

        await _unitOfWork.CommitAsync();

        return meetingGroupProposal.Id.Value;
    }
}
