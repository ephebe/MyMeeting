using BuildingBlocks.Abstractions.Domain;
using MyMeeting.Services.Meetings.Core.MeetingGroups;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingComments.Rules;

public class RemovingReasonCanBeProvidedOnlyByGroupOrganizerRule : IBusinessRule
{
    private readonly MeetingGroup _meetingGroup;
    private readonly MemberId _removingMemberId;
    private readonly string _removingReason;

    public RemovingReasonCanBeProvidedOnlyByGroupOrganizerRule(MeetingGroup meetingGroup, MemberId removingMemberId, string removingReason)
    {
        _meetingGroup = meetingGroup;
        _removingMemberId = removingMemberId;
        _removingReason = removingReason;
    }

    public bool IsBroken() =>
        !string.IsNullOrEmpty(_removingReason) && !_meetingGroup.IsOrganizer(_removingMemberId);

    public string Message => "Only group organizer can provide comment's removing reason.";
}
