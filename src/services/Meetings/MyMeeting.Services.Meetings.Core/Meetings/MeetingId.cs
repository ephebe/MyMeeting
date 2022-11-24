using Ardalis.GuardClauses;
using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings;

public record MeetingId : AggregateId
{
    public MeetingId(Guid value) : base(value)
    {
        Guard.Against.NullOrEmpty(value, nameof(value));
    }
}
