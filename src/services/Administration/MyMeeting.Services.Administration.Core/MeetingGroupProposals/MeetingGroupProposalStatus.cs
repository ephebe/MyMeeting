using BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Core.MeetingGroupProposals;

public class MeetingGroupProposalStatus : ValueObject
{
    private MeetingGroupProposalStatus(string value)
    {
        Value = value;
    }

    public static MeetingGroupProposalStatus ToVerify => new MeetingGroupProposalStatus("ToVerify");

    public static MeetingGroupProposalStatus Verified => new MeetingGroupProposalStatus("Verified");

    public string Value { get; }

    internal static MeetingGroupProposalStatus Create(string value)
    {
        return new MeetingGroupProposalStatus(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
