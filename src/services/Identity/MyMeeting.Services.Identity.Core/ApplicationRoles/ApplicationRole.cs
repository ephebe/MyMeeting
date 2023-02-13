using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Core.ApplicationRoles;

public class ApplicationRole : IdentityRole<Guid>
{
    public static ApplicationRole User => new()
    {
        Name = MeetingIdentityConstants.Role.User,
        NormalizedName = nameof(User).ToUpper(CultureInfo.InvariantCulture),
    };

    public static ApplicationRole Admin => new()
    {
        Name = MeetingIdentityConstants.Role.Admin,
        NormalizedName = nameof(Admin).ToUpper(CultureInfo.InvariantCulture)
    };
}
