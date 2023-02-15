using Humanizer;
using MassTransit;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMeeting.Services.Shared.Administration.MeetingGroupProposals.Events.Integration;
using MyMeeting.Services.Meetings.Api.MeetingGroupProposals;
using MyMeeting.Services.Shared.Meetings.IntegrationEvents;

namespace MyMeeting.Services.Meeting.Api.Extensions;

internal static class MassTransitExtensions
{
    internal static void AddMeetingGroupProposeIntegrationEventPublishers(this IRabbitMqBusFactoryConfigurator cfg)
    {
        cfg.Message<MeetingGroupProposedIntegrationEvent>(e =>
            e.SetEntityName($"{nameof(MeetingGroupProposedIntegrationEvent).Underscore()}.input_exchange")); // name of the primary exchange
        cfg.Publish<MeetingGroupProposedIntegrationEvent>(e => e.ExchangeType = ExchangeType.Direct); // primary exchange type
        cfg.Send<MeetingGroupProposedIntegrationEvent>(e =>
        {
            // route by message type to binding fanout exchange (exchange to exchange binding)
            e.UseRoutingKeyFormatter(context =>
                context.Message.GetType().Name.Underscore());
        });
    }

    internal static void AddMeetingGroupProposalAcceptedIntegrationEventEndpoints(this IRabbitMqBusFactoryConfigurator cfg, IBusRegistrationContext context)
    {
        cfg.ReceiveEndpoint(nameof(MeetingGroupProposalAcceptedIntegrationEvent).Underscore(), re =>
        {
            // turns off default fanout settings
            re.ConfigureConsumeTopology = false;

            // a replicated queue to provide high availability and data safety. available in RMQ 3.8+
            re.SetQuorumQueue();

            re.Bind($"{nameof(MeetingGroupProposalAcceptedIntegrationEvent).Underscore()}.input_exchange", e =>
            {
                e.RoutingKey = nameof(MeetingGroupProposalAcceptedIntegrationEvent).Underscore();
                e.ExchangeType = ExchangeType.Direct;
            });

            cfg.ConcurrentMessageLimit = 3;
            // https://github.com/MassTransit/MassTransit/discussions/3117
            // https://masstransit-project.com/usage/configuration.html#receive-endpoints
            re.ConfigureConsumer<MeetingGroupProposalAcceptedIntegrationEventConsumer>(context);

            re.RethrowFaultedMessages();
        });
    }
}
