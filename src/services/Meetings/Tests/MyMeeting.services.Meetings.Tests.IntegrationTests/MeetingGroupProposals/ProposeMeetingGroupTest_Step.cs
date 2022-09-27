using LightBDD.Framework;
using MyMeeting.Services.Meeting.Api.MeetingGroupProposals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.services.Meetings.Tests.IntegrationTests.MeetingGroupProposals
{
    public partial class ProposeMeetingGroupTest
    {
        private readonly HttpClient _client;
        private State<ProposeMeetingGroupRequest> _proposeMeetingGroupRequest;
        private State<HttpResponseMessage> _response;

        public ProposeMeetingGroupTest()
        {
            _client = TestServer.GetClient();
        }

        private async Task GivenAProposeMeetingGroupRequest()
        {
            _proposeMeetingGroupRequest = new ProposeMeetingGroupRequest
            {
                Name = "共進會",
                LocationCity = "Taichung",
                LocationCountryCode = "406"
            };
        }

        private async Task WhenIAskProposeMeetingGroup()
        {
            _response = await _client.PostAsync("api/meetings/MeetingGroupProposals", _proposeMeetingGroupRequest.ToJsonContent());
        }

        private async Task ThenResponseCode(HttpStatusCode code)
        {
            Assert.Equal(code, _response.GetValue().StatusCode);
        }

        private async Task ThenHeaderWithUrl()
        {
            Assert.NotNull(_response.GetValue().Headers.Location);
        }
    }
}
