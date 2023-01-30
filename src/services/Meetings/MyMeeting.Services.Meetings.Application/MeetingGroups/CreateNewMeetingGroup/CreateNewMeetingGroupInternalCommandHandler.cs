using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.Persistence;
using MediatR;
using MyMeeting.Services.Meetings.Core.MeetingGroupProposals;
using MyMeeting.Services.Meetings.Core.MeetingGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Application.MeetingGroups.CreateNewMeetingGroup;

public class CreateNewMeetingGroupInternalCommandHandler : ICommandHandler<CreateNewMeetingGroupInternalCommand>
{
    private readonly IRepository<MeetingGroup, MeetingGroupId> _meetingGroupRepository;
    private readonly IRepository<MeetingGroupProposal, MeetingGroupProposalId> _meetingGroupProposalRepository;

    public CreateNewMeetingGroupInternalCommandHandler(
            IRepository<MeetingGroup, MeetingGroupId> meetingGroupRepository,
            IRepository<MeetingGroupProposal, MeetingGroupProposalId> meetingGroupProposalRepository)
    {
        _meetingGroupRepository = meetingGroupRepository;
        _meetingGroupProposalRepository = meetingGroupProposalRepository;
    }
    public async Task<Unit> Handle(CreateNewMeetingGroupInternalCommand request, CancellationToken cancellationToken)
    {
        var meetingGroupProposal = await _meetingGroupProposalRepository.FindByIdAsync(request.MeetingGroupProposalId);

        var meetingGroup = meetingGroupProposal.CreateMeetingGroup();

        await _meetingGroupRepository.AddAsync(meetingGroup);

        return Unit.Value;
    }
}
