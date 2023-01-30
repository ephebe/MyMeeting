using BuildingBlocks.Abstractions.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Application.MeetingGroups.LeaveMeetingGroup;

public class LeaveMeetingGroupCommand : ICommand
{
    public LeaveMeetingGroupCommand(Guid meetingGroupId)
    {
        MeetingGroupId = meetingGroupId;
    }

    internal Guid MeetingGroupId { get; }
}
