using BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyMeeting.Services.UserAccess.Core.UserRegistrations;

public class UserRegistrationStatus : ValueObject
{
    public static UserRegistrationStatus WaitingForConfirmation =>
        new UserRegistrationStatus(nameof(WaitingForConfirmation));

    public static UserRegistrationStatus Confirmed => new UserRegistrationStatus(nameof(Confirmed));

    public static UserRegistrationStatus Expired => new UserRegistrationStatus(nameof(Expired));

    public string Value { get; }

    private UserRegistrationStatus(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
