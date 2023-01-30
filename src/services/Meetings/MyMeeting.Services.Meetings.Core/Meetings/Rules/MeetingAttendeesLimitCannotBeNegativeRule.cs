using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Rules;

internal class MeetingAttendeesLimitCannotBeNegativeRule : IBusinessRule
{
    private readonly int? _attendeesLimit;

    public MeetingAttendeesLimitCannotBeNegativeRule(int? attendeesLimit)
    {
        _attendeesLimit = attendeesLimit;
    }

    public bool IsBroken() => _attendeesLimit.HasValue && _attendeesLimit.Value < 0;

    public string Message => "Attendees limit cannot be negative";
}
