using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.CQRS.Events.Internal;
using MyMeeting.Services.Meetings.Application.MeetingGroups.CreateNewMeetingGroup;
using MyMeeting.Services.Meetings.Application.Meetings.SendMeetingAttendeeAddedEmail;
using MyMeeting.Services.Meetings.Core.Meetings.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Application.Meetings.AddMeetingAttendee;

public class AddMeetingAttendeeDomainEventHandler : IDomainEventHandler<MeetingAttendeeAddedDomainEvent>
{
    private readonly ICommandProcessor _commandProcessor;

    public AddMeetingAttendeeDomainEventHandler(ICommandProcessor commandProcessor)
    {
        _commandProcessor = commandProcessor;
    }
    public async Task Handle(MeetingAttendeeAddedDomainEvent notification, CancellationToken cancellationToken)
    {
        await _commandProcessor.SendAsync(
                new SendMeetingAttendeeAddedEmailInternalCommand(
                    notification.AttendeeId,
                    notification.MeetingId));
    }
}
