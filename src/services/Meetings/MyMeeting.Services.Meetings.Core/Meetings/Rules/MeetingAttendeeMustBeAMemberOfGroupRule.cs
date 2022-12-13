using BuildingBlocks.Abstractions.Domain;
using MyMeeting.Services.Meetings.Core.MeetingGroups;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Rules;

public class MeetingAttendeeMustBeAMemberOfGroupRule : IBusinessRule
{
    private readonly MeetingGroup _meetingGroup;

    private readonly MemberId _attendeeId;

    internal MeetingAttendeeMustBeAMemberOfGroupRule(MemberId attendeeId, MeetingGroup meetingGroup)
    {
        _attendeeId = attendeeId;
        _meetingGroup = meetingGroup;
    }

    public bool IsBroken()
    {
        return !_meetingGroup.IsMemberOfGroup(_attendeeId);
    }

    public string Message => "Meeting attendee must be a member of group";
}
