﻿using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Core.CQRS.Commands;
using MyMeeting.Services.Meetings.Core.MeetingGroupProposals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Application.MeetingGroups.CreateNewMeetingGroup;

public record CreateNewMeetingGroupInternalCommand : InternalCommand
{
    public CreateNewMeetingGroupInternalCommand(MeetingGroupProposalId meetingGroupProposalId)
    {
        MeetingGroupProposalId = meetingGroupProposalId;
    }

    internal MeetingGroupProposalId MeetingGroupProposalId { get; }
}
