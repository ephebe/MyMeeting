using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings.Rules;

public class MeetingCannotBeChangedAfterStartRule : IBusinessRule
{
    private readonly MeetingTerm _meetingTerm;

    public MeetingCannotBeChangedAfterStartRule(MeetingTerm meetingTerm)
    {
        _meetingTerm = meetingTerm;
    }

    public bool IsBroken() => _meetingTerm.IsAfterStart();

    public string Message => "Meeting cannot be changed after start";
}
