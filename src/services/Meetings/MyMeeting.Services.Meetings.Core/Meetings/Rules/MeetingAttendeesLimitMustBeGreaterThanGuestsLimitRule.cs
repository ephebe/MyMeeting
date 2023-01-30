using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Rules;

internal class MeetingAttendeesLimitMustBeGreaterThanGuestsLimitRule : IBusinessRule
{
    private readonly int? _attendeesLimit;

    private readonly int _guestsLimit;

    public MeetingAttendeesLimitMustBeGreaterThanGuestsLimitRule(int? attendeesLimit, int guestsLimit)
    {
        _attendeesLimit = attendeesLimit;
        _guestsLimit = guestsLimit;
    }

    public bool IsBroken() => _attendeesLimit.HasValue && _attendeesLimit.Value < _guestsLimit;

    public string Message => "Attendees limit must be greater than guests limit";
}
