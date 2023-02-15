using BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyMeeting.Services.Payments.Core.MeetingFees;

public class MeetingFeeStatus : ValueObject
{
    public static MeetingFeeStatus WaitingForPayment => new MeetingFeeStatus(nameof(WaitingForPayment));

    public static MeetingFeeStatus Paid => new MeetingFeeStatus(nameof(Paid));

    public static MeetingFeeStatus Expired => new MeetingFeeStatus(nameof(Expired));

    public static MeetingFeeStatus Canceled => new MeetingFeeStatus(nameof(Canceled));

    public string Code { get; }

    private MeetingFeeStatus(string code)
    {
        Code = code;
    }

    public static MeetingFeeStatus Of(string code)
    {
        return new MeetingFeeStatus(code);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }
}
