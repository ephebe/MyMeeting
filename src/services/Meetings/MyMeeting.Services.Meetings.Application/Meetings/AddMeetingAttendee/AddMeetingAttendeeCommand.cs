using BuildingBlocks.Abstractions.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Application.Meetings.AddMeetingAttendee;

public class AddMeetingAttendeeCommand : ICommand
{
    public Guid MeetingId { get; }

    public int GuestsNumber { get; }

    public AddMeetingAttendeeCommand(Guid meetingId, int guestsNumber)
    {
        MeetingId = meetingId;
        GuestsNumber = guestsNumber;
    }
}
