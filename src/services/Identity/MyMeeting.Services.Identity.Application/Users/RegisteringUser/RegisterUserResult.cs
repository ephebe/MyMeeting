using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Application.Users.RegisteringUser;

public record RegisterUserResult(IdentityUserDto? UserIdentity);
