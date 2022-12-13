using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Rules;

public class MeetingMustHaveAtLeastOneHostRule : IBusinessRule
{
    private readonly int _meetingHostNumber;

    public MeetingMustHaveAtLeastOneHostRule(int meetingHostNumber)
    {
        _meetingHostNumber = meetingHostNumber;
    }

    public bool IsBroken() => _meetingHostNumber == 0;

    public string Message => "Meeting must have at least one host";
}
