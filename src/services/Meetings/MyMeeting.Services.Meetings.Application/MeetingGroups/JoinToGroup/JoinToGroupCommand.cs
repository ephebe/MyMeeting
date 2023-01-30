using BuildingBlocks.Abstractions.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Application.MeetingGroups.JoinToGroup;

public class JoinToGroupCommand : ICommand
{
    public JoinToGroupCommand(Guid meetingGroupId)
    {
        MeetingGroupId = meetingGroupId;
    }

    internal Guid MeetingGroupId { get; }
}
