using BuildingBlocks.Abstractions.Domain;
using MyMeeting.Services.Meetings.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Rules;

public class MeetingGroupProposalCannotBeAcceptedMoreThanOnceRule : IBusinessRule
{
    private readonly MeetingGroupProposalStatus _actualStatus;

    internal MeetingGroupProposalCannotBeAcceptedMoreThanOnceRule(MeetingGroupProposalStatus actualStatus)
    {
        _actualStatus = actualStatus;
    }

    public bool IsBroken() => _actualStatus.IsAccepted;

    public string Message => "Meeting group proposal cannot be accepted more than once rule";
}
