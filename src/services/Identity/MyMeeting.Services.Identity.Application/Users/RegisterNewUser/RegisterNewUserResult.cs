using MyMeeting.Services.Identity.Application.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Application.Users.RegisterNewUser;

public record RegisterNewUserResult(IdentityUserDto? UserIdentity);

