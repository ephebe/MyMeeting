using BuildingBlocks.Abstractions.Domain;
using MyMeeting.Services.Meetings.Core.MeetingGroups;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Rules;

public class OnlyMeetingOrGroupOrganizerCanSetMeetingMemberRolesRule : IBusinessRule
{
    private readonly MemberId _settingMemberId;
    private readonly MeetingGroup _meetingGroup;
    private readonly List<MeetingAttendee> _attendees;

    public OnlyMeetingOrGroupOrganizerCanSetMeetingMemberRolesRule(MemberId settingMemberId, MeetingGroup meetingGroup, List<MeetingAttendee> attendees)
    {
        _settingMemberId = settingMemberId;
        _meetingGroup = meetingGroup;
        _attendees = attendees;
    }

    public bool IsBroken()
    {
        var settingMember = _attendees.SingleOrDefault(x => x.IsActiveAttendee(_settingMemberId));

        var isHost = settingMember != null && settingMember.IsActiveHost();
        var isOrganizer = _meetingGroup.IsOrganizer(_settingMemberId);

        return !isHost && !isOrganizer;
    }

    public string Message => "Only meeting host or group organizer can set meeting member roles";
}
