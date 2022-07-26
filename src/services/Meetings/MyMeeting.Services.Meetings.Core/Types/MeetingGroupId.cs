using Ardalis.GuardClauses;
using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Types;

public record MeetingGroupId : AggregateId
{
    public MeetingGroupId(long value) : base(value)
    {
        Guard.Against.NegativeOrZero(value, nameof(value));
    }

    public static implicit operator long(MeetingGroupId id) => Guard.Against.Null(id.Value, nameof(id.Value));

    public static implicit operator MeetingGroupId(long id) => new(id);
}
