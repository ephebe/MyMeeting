﻿using BuildingBlocks.Abstractions.Domain;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Rules;

internal class OnlyMeetingAttendeeCanHaveChangedRoleRule : IBusinessRule
{
    private readonly List<MeetingAttendee> _attendees;

    private readonly MemberId _newOrganizerId;

    internal OnlyMeetingAttendeeCanHaveChangedRoleRule(List<MeetingAttendee> attendees, MemberId newOrganizerId)
    {
        _attendees = attendees;
        _newOrganizerId = newOrganizerId;
    }

    public bool IsBroken() => _attendees.SingleOrDefault(x => x.IsActiveAttendee(_newOrganizerId)) == null;

    public string Message => "Only meeting attendee can be se as organizer of meeting";
}