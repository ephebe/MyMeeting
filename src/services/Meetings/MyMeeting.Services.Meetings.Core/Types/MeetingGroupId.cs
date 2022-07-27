﻿using Ardalis.GuardClauses;
using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Types;

public record MeetingGroupId : AggregateId
{
    public MeetingGroupId(Guid value) : base(value)
    {
        Guard.Against.Null(value, nameof(value));
    }
}
