using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.Scheduler;
using MassTransit;
using MediatR;
using MyMeeting.Services.Payments.Application.MeetingFees.CreateMeetingFee;
using MyMeeting.Services.Shared.Meetings.IntegrationEvents;

namespace MyMeeting.Services.Payments.Api.MeetingFees;

public class MeetingAttendeeAddedIntegrationEventConsumer : IConsumer<MeetingAttendeeAddedIntegrationEvent>
{
    private readonly ICommandProcessor _commandProcessor;
    private readonly ILogger<MeetingAttendeeAddedIntegrationEvent> _logger;

    public MeetingAttendeeAddedIntegrationEventConsumer(
        ICommandProcessor commandProcessor,
        ILogger<MeetingAttendeeAddedIntegrationEvent> logger
        )
    {
        _commandProcessor = commandProcessor;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<MeetingAttendeeAddedIntegrationEvent> context)
    {
        var meetingAttendeeAdd = context.Message;

        if (meetingAttendeeAdd.FeeValue.HasValue)
        {
            await _commandProcessor.ScheduleAsync(new CreateMeetingFeeInternalCommand(
                Guid.NewGuid(),
                    meetingAttendeeAdd.AttendeeId,
                    meetingAttendeeAdd.MeetingId,
                    meetingAttendeeAdd.FeeValue.Value,
                    meetingAttendeeAdd.FeeCurrency));
        }
    }
}
