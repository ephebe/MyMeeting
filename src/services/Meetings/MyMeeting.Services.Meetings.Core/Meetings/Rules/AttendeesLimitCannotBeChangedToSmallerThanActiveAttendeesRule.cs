using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Rules;
public class AttendeesLimitCannotBeChangedToSmallerThanActiveAttendeesRule : IBusinessRule
{
    private readonly int? _attendeesLimit;

    private readonly int _allActiveAttendeesWithGuestsNumber;

    internal AttendeesLimitCannotBeChangedToSmallerThanActiveAttendeesRule(
        MeetingLimits meetingLimits,
        int allActiveAttendeesWithGuestsNumber)
    {
        this._attendeesLimit = meetingLimits.AttendeesLimit;
        this._allActiveAttendeesWithGuestsNumber = allActiveAttendeesWithGuestsNumber;
    }

    public bool IsBroken() => _attendeesLimit.HasValue && _attendeesLimit.Value < _allActiveAttendeesWithGuestsNumber;

    public string Message => "Attendees limit cannot be change to smaller than active attendees number";
}
