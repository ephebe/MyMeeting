using BuildingBlocks.Abstractions.Domain;
using MyMeeting.Services.Meetings.Core.MeetingGroups;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingCommentingConfigurations.Rules;

public class MeetingCommentingCanBeDisabledOnlyByGroupOrganizerRule : IBusinessRule
{
    private readonly MeetingGroup _meetingGroup;
    private readonly MemberId _disablingMemberId;

    public MeetingCommentingCanBeDisabledOnlyByGroupOrganizerRule(MemberId disablingMemberId, MeetingGroup meetingGroup)
    {
        _meetingGroup = meetingGroup;
        _disablingMemberId = disablingMemberId;
    }

    public bool IsBroken() => !_meetingGroup.IsOrganizer(_disablingMemberId);

    public string Message => "Commenting for meeting can be disabled only by group organizer";
}