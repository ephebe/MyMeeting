using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.Persistence;
using MediatR;
using MyMeeting.Services.Meetings.Core.MeetingGroups;
using MyMeeting.Services.Meetings.Core.Meetings;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Application.Meetings.AddMeetingAttendee;

internal class AddMeetingAttendeeCommandHandler : ICommandHandler<AddMeetingAttendeeCommand>
{
    private readonly IMemberContext _memberContext;
    private readonly IRepository<Meeting, MeetingId> _meetingRepository;
    private readonly IRepository<MeetingGroup, MeetingGroupId> _meetingGroupRepository;

    public AddMeetingAttendeeCommandHandler(
        IMemberContext memberContext,
        IRepository<Meeting,MeetingId> meetingRepository,
        IRepository<MeetingGroup,MeetingGroupId> meetingGroupRepository)
    {
        _memberContext = memberContext;
        _meetingRepository = meetingRepository;
        _meetingGroupRepository = meetingGroupRepository;
    }

    public async Task<Unit> Handle(AddMeetingAttendeeCommand request, CancellationToken cancellationToken)
    {
        var meeting = await _meetingRepository.FindByIdAsync(new MeetingId(request.MeetingId));

        var meetingGroup = await _meetingGroupRepository.FindByIdAsync(meeting.GetMeetingGroupId());

        meeting.AddAttendee(meetingGroup, _memberContext.MemberId, request.GuestsNumber);

        return Unit.Value;
    }
}
