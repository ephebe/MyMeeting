using Humanizer;
using MassTransit;
using RabbitMQ.Client;
using MyMeeting.Services.Shared.Meetings.MeetingGroupProposals.Events.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meeting.Api.Extensions;

internal static class MassTransitExtensions
{
    internal static void AddMeetingGroupProposePublishers(this IRabbitMqBusFactoryConfigurator cfg)
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
}
