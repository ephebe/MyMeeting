using BuildingBlocks.Abstractions.CQRS.Commands;
using MassTransit;
using Microsoft.Extensions.Logging;
using MyMeeting.Services.Meetings.Application.MeetingGroupProposals;
using MyMeeting.Services.Shared.Administration.MeetingGroupProposals.Events.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Api.MeetingGroupProposals;

public class MeetingGroupProposalAcceptedIntegrationEventConsumer : IConsumer<MeetingGroupProposalAcceptedIntegrationEvent>
{
    private readonly ICommandProcessor _commandProcessor;
    private readonly ILogger<MeetingGroupProposalAcceptedIntegrationEventConsumer> _logger;

    public MeetingGroupProposalAcceptedIntegrationEventConsumer(
        ICommandProcessor commandProcessor,
        ILogger<MeetingGroupProposalAcceptedIntegrationEventConsumer> logger
        ) 
    {
        _commandProcessor = commandProcessor;
        _logger = logger;
    }
    public async Task Consume(ConsumeContext<MeetingGroupProposalAcceptedIntegrationEvent> context)
    {
        var meetingGroupProposeAccept = context.Message;

        await _commandProcessor.SendAsync(
            new AcceptMeetingGroupProposalCommand(
                meetingGroupProposeAccept.MeetingGroupProposalId));

        _logger.LogInformation(
            "Sending restock notification command for product {ProductId}",
            meetingGroupProposeAccept.MeetingGroupProposalId);
    }
}
