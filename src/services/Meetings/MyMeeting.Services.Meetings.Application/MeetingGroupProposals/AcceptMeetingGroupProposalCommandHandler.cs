using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.Persistence;
using MediatR;
using MyMeeting.Services.Meetings.Core.MeetingGroupProposals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Application.MeetingGroupProposals;
public class AcceptMeetingGroupProposalCommandHandler : ICommandHandler<AcceptMeetingGroupProposalCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<MeetingGroupProposal, MeetingGroupProposalId> _meetingGroupProposalRepository;
    
    public AcceptMeetingGroupProposalCommandHandler(
         IUnitOfWork unitOfWork,
            IRepository<MeetingGroupProposal, MeetingGroupProposalId> meetingGroupProposalRepository) 
    {
        _unitOfWork = unitOfWork;
        _meetingGroupProposalRepository = meetingGroupProposalRepository;
    }

    public async Task<Unit> Handle(AcceptMeetingGroupProposalCommand request, CancellationToken cancellationToken)
    {
        var meetingGroupProposal = await _meetingGroupProposalRepository.FindByIdAsync(new MeetingGroupProposalId(request.MeetingGroupProposalId));

        meetingGroupProposal.Accept();

        return Unit.Value;
    }
}
