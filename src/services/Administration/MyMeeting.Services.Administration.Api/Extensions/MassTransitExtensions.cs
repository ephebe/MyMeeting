using Humanizer;
using MassTransit;
using RabbitMQ.Client;
using MyMeeting.Services.Administration.Application.MeetingGroupProposals;
using MyMeeting.Services.Shared.Meetings.MeetingGroupProposals.Events.Integration;

namespace MyMeeting.Services.Administration.Api.Extensions;

public static class MassTransitExtensions
{
    public static void AddMeetingGroupProposedIntegrationEventEndpoints(this IRabbitMqBusFactoryConfigurator cfg, IBusRegistrationContext context)
    {
        cfg.ReceiveEndpoint(nameof(MeetingGroupProposedIntegrationEvent).Underscore(), re =>
        {
            // turns off default fanout settings
            re.ConfigureConsumeTopology = false;

            // a replicated queue to provide high availability and data safety. available in RMQ 3.8+
            re.SetQuorumQueue();

            re.Bind($"{nameof(MeetingGroupProposedIntegrationEvent).Underscore()}.input_exchange", e =>
            {
                e.RoutingKey = nameof(MeetingGroupProposedIntegrationEvent).Underscore();
                e.ExchangeType = ExchangeType.Direct;
            });

            // https://github.com/MassTransit/MassTransit/discussions/3117
            // https://masstransit-project.com/usage/configuration.html#receive-endpoints
            re.ConfigureConsumer<MeetingGroupProposedIntegrationEventConsumer>(context);

            re.RethrowFaultedMessages();
        });
    }
}
