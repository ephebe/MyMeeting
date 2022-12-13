using BuildingBlocks.Abstractions.Domain;
using BuildingBlocks.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Rules;

public class AttendeeCanBeAddedOnlyInRsvpTermRule : IBusinessRule
{
    private readonly Term _rsvpTerm;

    internal AttendeeCanBeAddedOnlyInRsvpTermRule(Term rsvpTerm)
    {
        _rsvpTerm = rsvpTerm;
    }

    public bool IsBroken() => !_rsvpTerm.IsInTerm(SystemClock.Now);

    public string Message => "Attendee can be added only in RSVP term";
}
