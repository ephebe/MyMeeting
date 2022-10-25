using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Core.MeetingGroupProposals.Rule;

public class MeetingGroupProposalRejectionMustHaveAReasonRule : IBusinessRule
{
    private readonly string _reason;

    internal MeetingGroupProposalRejectionMustHaveAReasonRule(string reason)
    {
        _reason = reason;
    }

    public string Message => "Meeting group proposal rejection must have a reason";

    public bool IsBroken() => string.IsNullOrEmpty(_reason);
}
