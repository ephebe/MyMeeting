using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.Persistence;
using MediatR;
using MyMeeting.Services.Meetings.Core.Meetings;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Application.Meetings.CancelMeeting;

internal class CancelMeetingCommandHandler : ICommandHandler<CancelMeetingCommand>
{
    private readonly IRepository<Meeting, MeetingId> _meetingRepository;
    private readonly IMemberContext _memberContext;

    internal CancelMeetingCommandHandler(
        IRepository<Meeting,MeetingId> meetingRepository, 
        IMemberContext memberContext)
    {
        _meetingRepository = meetingRepository;
        _memberContext = memberContext;
    }

    public async Task<Unit> Handle(CancelMeetingCommand request, CancellationToken cancellationToken)
    {
        var meeting = await _meetingRepository.FindByIdAsync(new MeetingId(request.MeetingId));

        meeting?.Cancel(_memberContext.MemberId);

        return Unit.Value;
    }
}
