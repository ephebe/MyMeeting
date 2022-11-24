using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingGroups.Rules;

public class MeetingCanBeOrganizedOnlyByPayedGroupRule : IBusinessRule
{
    private readonly DateTime? _paymentDateTo;

    internal MeetingCanBeOrganizedOnlyByPayedGroupRule(DateTime? paymentDateTo)
    {
        _paymentDateTo = paymentDateTo;
    }

    public bool IsBroken() => !_paymentDateTo.HasValue || _paymentDateTo < SystemClock.Now;

    public string Message => "Meeting can be organized only by payed group";
}
