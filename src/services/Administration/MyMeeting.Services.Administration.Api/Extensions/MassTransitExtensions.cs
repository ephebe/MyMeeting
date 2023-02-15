using Humanizer;
using MassTransit;
using RabbitMQ.Client;
using MyMeeting.Services.Administration.Application.MeetingGroupProposals;
using MyMeeting.Services.Shared.Administration.MeetingGroupProposals.Events.Integration;
using MyMeeting.Services.Administration.Api.MeetingGroupProposals;
using MyMeeting.Services.Shared.Meetings.IntegrationEvents;

namespace MyMeeting.Services.Administration.Api.Extensions;

internal static class MassTransitExtensions
{
    internal static void AddMeetingGroupProposedIntegrationEventEndpoints(this IRabbitMqBusFactoryConfigurator cfg, IBusRegistrationContext context)
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

            cfg.ConcurrentMessageLimit = 3;
            // https://github.com/MassTransit/MassTransit/discussions/3117
            // https://masstransit-project.com/usage/configuration.html#receive-endpoints
            re.ConfigureConsumer<MeetingGroupProposedIntegrationEventConsumer>(context);

            re.RethrowFaultedMessages();
        });
    }

    internal static void AddMeetingGroupProposeAcceptedIntegrationEventPublishers(this IRabbitMqBusFactoryConfigurator cfg)
    {
        cfg.Message<MeetingGroupProposalAcceptedIntegrationEvent>(e =>
            e.SetEntityName($"{nameof(MeetingGroupProposalAcceptedIntegrationEvent).Underscore()}.input_exchange")); // name of the primary exchange
        cfg.Publish<MeetingGroupProposalAcceptedIntegrationEvent>(e => e.ExchangeType = ExchangeType.Direct); // primary exchange type
        cfg.Send<MeetingGroupProposalAcceptedIntegrationEvent>(e =>
        {
            // route by message type to binding fanout exchange (exchange to exchange binding)
            e.UseRoutingKeyFormatter(context =>
                context.Message.GetType().Name.Underscore());
        });
    }
}
