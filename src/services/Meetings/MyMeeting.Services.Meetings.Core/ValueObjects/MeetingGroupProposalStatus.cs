using BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.ValueObjects;

public class MeetingGroupProposalStatus : ValueObject
{
    public string Value { get; }

    internal static MeetingGroupProposalStatus InVerification => new MeetingGroupProposalStatus("InVerification");

    internal static MeetingGroupProposalStatus Accepted => new MeetingGroupProposalStatus("Accepted");

    internal bool IsAccepted => Value == "Accepted";

    private MeetingGroupProposalStatus(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
