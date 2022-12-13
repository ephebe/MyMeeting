﻿using BuildingBlocks.Abstractions.Domain;
using MyMeeting.Services.Meetings.Core.MeetingGroups;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingCommentingConfigurations.Rules;

public class MeetingCommentingCanBeEnabledOnlyByGroupOrganizerRule : IBusinessRule
{
    private readonly MeetingGroup _meetingGroup;
    private readonly MemberId _enablingMemberId;

    public MeetingCommentingCanBeEnabledOnlyByGroupOrganizerRule(MemberId enablingMemberId, MeetingGroup meetingGroup)
    {
        _meetingGroup = meetingGroup;
        _enablingMemberId = enablingMemberId;
    }

    public bool IsBroken() => !_meetingGroup.IsOrganizer(_enablingMemberId);

    public string Message => "Commenting for meeting can be enabled only by group organizer";
}
