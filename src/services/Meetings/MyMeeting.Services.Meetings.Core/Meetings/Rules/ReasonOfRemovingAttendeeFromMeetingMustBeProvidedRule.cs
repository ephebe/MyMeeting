using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Rules;

internal record ReasonOfRemovingAttendeeFromMeetingMustBeProvidedRule : IBusinessRule
{
    private readonly string _reason;

    internal ReasonOfRemovingAttendeeFromMeetingMustBeProvidedRule(string reason)
    {
        _reason = reason;
    }

    public bool IsBroken() => string.IsNullOrEmpty(_reason);

    public string Message => "Reason of removing attendee from meeting must be provided";
}
