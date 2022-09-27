using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.services.Meetings.Tests.IntegrationTests.MeetingGroupProposals;

[FeatureDescription(
@"")]
public partial class ProposeMeetingGroupTest : FeatureFixture
{
    [Scenario]
    public async Task CreateProposeMeetingGroup()
    {
        await Runner.RunScenarioAsync(
            _ => GivenAProposeMeetingGroupRequest(),
            _ => WhenIAskProposeMeetingGroup(),
            _ => ThenResponseCode(HttpStatusCode.Created),
            _ => ThenHeaderWithUrl());
    }
}
