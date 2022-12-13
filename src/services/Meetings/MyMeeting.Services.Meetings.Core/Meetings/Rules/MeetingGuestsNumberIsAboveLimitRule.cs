using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Rules;

public class MeetingGuestsNumberIsAboveLimitRule : IBusinessRule
{
    private readonly int _guestsNumber;

    private readonly int _guestsLimit;

    public MeetingGuestsNumberIsAboveLimitRule(int guestsLimit, int guestsNumber)
    {
        _guestsNumber = guestsNumber;
        _guestsLimit = guestsLimit;
    }

    public bool IsBroken() => this._guestsLimit > 0 && this._guestsLimit < _guestsNumber;

    public string Message => "Meeting guests number is above limit";
}