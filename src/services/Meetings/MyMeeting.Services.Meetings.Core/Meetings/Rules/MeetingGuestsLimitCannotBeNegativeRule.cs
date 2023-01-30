using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Rules;

internal class MeetingGuestsLimitCannotBeNegativeRule : IBusinessRule
{
    private readonly int _guestsLimit;

    public MeetingGuestsLimitCannotBeNegativeRule(int guestsLimit)
    {
        _guestsLimit = guestsLimit;
    }

    public bool IsBroken() => _guestsLimit < 0;

    public string Message => "Guests limit cannot be negative";
}
