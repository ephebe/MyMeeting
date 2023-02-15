using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.CQRS.Events.Internal;
using MyMeeting.Services.Meetings.Application.MeetingGroups;
using MyMeeting.Services.Meetings.Application.MeetingGroups.CreateNewMeetingGroup;
using MyMeeting.Services.Meetings.Core.MeetingGroupProposals.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Application.MeetingGroupProposals.AcceptMeetingGroupProposal;

internal class MeetingGroupProposalAcceptedDomainEventHandler : IDomainEventHandler<MeetingGroupProposalAcceptedDomainEvent>
{
    private readonly ICommandProcessor _commandProcessor;

    internal MeetingGroupProposalAcceptedDomainEventHandler(ICommandProcessor commandProcessor)
    {
        _commandProcessor = commandProcessor;
    }

    public async Task Handle(MeetingGroupProposalAcceptedDomainEvent notification, CancellationToken cancellationToken)
    {
        await _commandProcessor.ScheduleAsync(
                new CreateNewMeetingGroupInternalCommand(
                    notification.MeetingGroupProposalId));
    }
}
