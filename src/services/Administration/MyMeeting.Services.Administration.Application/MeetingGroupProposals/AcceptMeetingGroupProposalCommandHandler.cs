using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.Persistence;
using MediatR;
using MyMeeting.Services.Administration.Core.MeetingGroupProposals;
using MyMeeting.Services.Administration.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Application.MeetingGroupProposals;

public class AcceptMeetingGroupProposalCommandHandler : ICommandHandler<AcceptMeetingGroupProposalCommand, Unit>
{
    private IUnitOfWork _unitOfWork;
    private readonly IRepository<MeetingGroupProposal, MeetingGroupProposalId> _meetingGroupProposalRepository;
    private readonly IUserContext _userContext;

    public AcceptMeetingGroupProposalCommandHandler(
        IUnitOfWork unitOfWork,
        IRepository<MeetingGroupProposal, MeetingGroupProposalId> meetingGroupProposalRepository, 
        IUserContext userContext)
    {
        _unitOfWork = unitOfWork;
        _meetingGroupProposalRepository = meetingGroupProposalRepository;
        _userContext = userContext;
    }

    public async Task<Unit> Handle(AcceptMeetingGroupProposalCommand request, CancellationToken cancellationToken)
    {
        var meetingGroupProposal = await _meetingGroupProposalRepository.FindByIdAsync(new MeetingGroupProposalId(request.MeetingGroupProposalId));

        meetingGroupProposal.Accept(_userContext.UserId);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}
