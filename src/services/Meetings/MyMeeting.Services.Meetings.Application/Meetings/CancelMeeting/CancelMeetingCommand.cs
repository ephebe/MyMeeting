using BuildingBlocks.Abstractions.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Application.Meetings.CancelMeeting;

public class CancelMeetingCommand : ICommand
{
    public CancelMeetingCommand(Guid meetingId)
    {
        MeetingId = meetingId;
    }

    public Guid MeetingId { get; }
}
