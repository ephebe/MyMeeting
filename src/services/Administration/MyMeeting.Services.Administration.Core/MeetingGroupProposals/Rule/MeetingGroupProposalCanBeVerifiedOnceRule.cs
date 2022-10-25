using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Core.MeetingGroupProposals.Rule;

public class MeetingGroupProposalCanBeVerifiedOnceRule : IBusinessRule
{
    private readonly MeetingGroupProposalDecision _actualDecision;

    internal MeetingGroupProposalCanBeVerifiedOnceRule(MeetingGroupProposalDecision actualDecision)
    {
        _actualDecision = actualDecision;
    }

    public string Message => "Meeting group proposal can be verified only once";

    public bool IsBroken() => _actualDecision != MeetingGroupProposalDecision.NoDecision;
}
