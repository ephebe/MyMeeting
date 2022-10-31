using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.Persistence;
using MyMeeting.Services.Administration.Core.MeetingGroupProposals;
using MyMeeting.Services.Administration.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Application.MeetingGroupProposals;

public class RequestMeetingGroupProposalVerificationCommandHandler : ICommandHandler<RequestMeetingGroupProposalVerificationCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<MeetingGroupProposal, MeetingGroupProposalId> _meetingGroupProposalRepository;

    public RequestMeetingGroupProposalVerificationCommandHandler(
        IUnitOfWork unitOfWork,
        IRepository<MeetingGroupProposal, MeetingGroupProposalId> meetingGroupProposalRepository
        )
    {
        _unitOfWork = unitOfWork;
        _meetingGroupProposalRepository = meetingGroupProposalRepository;
    }

    public async Task<Guid> Handle(RequestMeetingGroupProposalVerificationCommand request, CancellationToken cancellationToken)
    {
        var meetingGroupProposal = MeetingGroupProposal.CreateToVerify(
            request.MeetingGroupProposalId,
            request.Name,
            request.Description,
            MeetingGroupLocation.Create(request.LocationCity, request.LocationCountryCode),
            new UserId(request.ProposalUserId),
            request.ProposalDate);

        await _meetingGroupProposalRepository.AddAsync(meetingGroupProposal);

        await _unitOfWork.CommitAsync();

        return meetingGroupProposal.Id.Value;
    }
}
