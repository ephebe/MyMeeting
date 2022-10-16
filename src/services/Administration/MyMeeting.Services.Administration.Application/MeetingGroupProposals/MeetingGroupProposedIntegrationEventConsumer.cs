using MassTransit;
using MyMeeting.Services.Shared.Meetings.MeetingGroupProposals.Events.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Application.MeetingGroupProposals;

public class MeetingGroupProposedIntegrationEventConsumer : IConsumer<MeetingGroupProposedIntegrationEvent>
{
    public Task Consume(ConsumeContext<MeetingGroupProposedIntegrationEvent> context)
    {
        throw new NotImplementedException();
    }
}
