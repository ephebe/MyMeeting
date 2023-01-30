using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.Persistence;
using BuildingBlocks.Abstractions.Persistence.EfCore;
using MyMeeting.Services.Meetings.Application.MeetingGroups.CreateNewMeetingGroup;
using MyMeeting.Services.Meetings.Core.MeetingGroups;
using MyMeeting.Services.Meetings.Core.Meetings;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Application.Meetings.CreateMeeting;

internal class CreateMeetingCommandHandler : ICommandHandler<CreateMeetingCommand,Guid>
{
    private readonly IMemberContext _memberContext;
    private readonly IRepository<Meeting, MeetingId> _meetingRepository;
    private readonly IRepository<MeetingGroup, MeetingGroupId> _meetingGroupRepository;

    internal CreateMeetingCommandHandler(
        IMemberContext memberContext,
        IRepository<Meeting, MeetingId> meetingRepository,
        IRepository<MeetingGroup,MeetingGroupId> meetingGroupRepository)
    {
        _memberContext = memberContext;
        _meetingRepository = meetingRepository;
        _meetingGroupRepository = meetingGroupRepository;
    }

    public async Task<Guid> Handle(CreateMeetingCommand request, CancellationToken cancellationToken)
    {
        var meetingGroup = await _meetingGroupRepository.FindByIdAsync(new MeetingGroupId(request.MeetingGroupId));

        var hostsMembersIds = request.HostMemberIds.Select(x => new MemberId(x)).ToList();

        var meeting = meetingGroup.CreateMeeting(
            request.Title,
            MeetingTerm.CreateNewBetweenDates(request.TermStartDate, request.TermStartDate),
            request.Description,
            MeetingLocation.CreateNew(request.MeetingLocationName, request.MeetingLocationAddress, request.MeetingLocationPostalCode, request.MeetingLocationCity),
            request.AttendeesLimit,
            request.GuestsLimit,
            Term.CreateNewBetweenDates(request.RSVPTermStartDate, request.RSVPTermEndDate),
            request.EventFeeValue.HasValue ? MoneyValue.Of(request.EventFeeValue.Value, request.EventFeeCurrency) : MoneyValue.Undefined,
            hostsMembersIds,
            _memberContext.MemberId);

        await _meetingRepository.AddAsync(meeting);

        return meeting.Id.Value;
    }
}
