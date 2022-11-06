using BuildingBlocks.Abstractions.CQRS.Commands;
using MassTransit;
using Microsoft.Extensions.Logging;
using MyMeeting.Services.Shared.Meetings.MeetingGroupProposals.Events.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Application.MeetingGroupProposals;

public class MeetingGroupProposedIntegrationEventConsumer : IConsumer<MeetingGroupProposedIntegrationEvent>
{
    private readonly ICommandProcessor _commandProcessor;
    private readonly ILogger<MeetingGroupProposedIntegrationEventConsumer> _logger;

    public MeetingGroupProposedIntegrationEventConsumer(
        ICommandProcessor commandProcessor,
        ILogger<MeetingGroupProposedIntegrationEventConsumer> logger)
    {
        _commandProcessor = commandProcessor;
        _logger = logger;
    }

    public Task Consume(ConsumeContext<MeetingGroupProposedIntegrationEvent> context)
    {
        var meetingGroupProposed = context.Message;

         _commandProcessor.SendAsync(
            new RequestMeetingGroupProposalVerificationCommand(
            Guid.NewGuid(),
            meetingGroupProposed.MeetingGroupProposalId,
            meetingGroupProposed.Name,
            meetingGroupProposed.Description,
            meetingGroupProposed.LocationCity,
            meetingGroupProposed.LocationCountryCode,
            meetingGroupProposed.ProposalUserId,
            meetingGroupProposed.ProposalDate));

        _logger.LogInformation(
            "Sending restock notification command for product {ProductId}",
            meetingGroupProposed.MeetingGroupProposalId);
        return Task.CompletedTask;
    }
}
