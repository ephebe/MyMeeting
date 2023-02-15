using BuildingBlocks.Core.CQRS.Commands;
using MyMeeting.Services.Meetings.Core.Meetings;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Application.Meetings.SendMeetingAttendeeAddedEmail;

public record SendMeetingAttendeeAddedEmailInternalCommand : InternalCommand
{
    internal MemberId AttendeeId { get; }

    internal MeetingId MeetingId { get; }

    internal SendMeetingAttendeeAddedEmailInternalCommand(MemberId attendeeId, MeetingId meetingId)
    {
        AttendeeId = attendeeId;
        MeetingId = meetingId;
    }
}
