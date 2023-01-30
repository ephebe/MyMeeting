using Microsoft.AspNetCore.Identity;
using MyMeeting.Services.Identity.Core.RefreshTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Core.ApplicationUsers;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? LastLoggedInAt { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; }
    public UserState UserState { get; set; }
    public DateTime CreatedAt { get; set; }
}
