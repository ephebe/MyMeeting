using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.Persistence;
using MediatR;
using MyMeeting.Services.Meetings.Application.MeetingGroups.CreateNewMeetingGroup;
using MyMeeting.Services.Meetings.Core.MeetingGroups;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Application.MeetingGroups.JoinToGroup;

public class JoinToGroupCommandHandler : ICommandHandler<JoinToGroupCommand>
{
    private readonly IRepository<MeetingGroup, MeetingGroupId> _meetingGroupRepository;
    private readonly IMemberContext _memberContext;

    internal JoinToGroupCommandHandler(
        IRepository<MeetingGroup, MeetingGroupId> meetingGroupRepository,
        IMemberContext memberContext)
    {
        _meetingGroupRepository = meetingGroupRepository;
        _memberContext = memberContext;
    }

    public async Task<Unit> Handle(JoinToGroupCommand request, CancellationToken cancellationToken)
    {
        var meetingGroup = await _meetingGroupRepository.FindByIdAsync(new MeetingGroupId(request.MeetingGroupId));

        meetingGroup.JoinToGroupMember(_memberContext.MemberId);

        return Unit.Value;
    }
}
