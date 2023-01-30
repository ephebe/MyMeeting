using BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.UserAccess.Core.Users;

public class UserRole : ValueObject
{
    public static UserRole Member => new UserRole(nameof(Member));

    public static UserRole Administrator => new UserRole(nameof(Administrator));

    public string Value { get; }

    private UserRole(string value)
    {
        this.Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
