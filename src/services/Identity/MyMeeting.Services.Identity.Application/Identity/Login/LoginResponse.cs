using MyMeeting.Services.Identity.Core.ApplicationUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Application.Identity.Login;

public class LoginResponse
{
    public LoginResponse(ApplicationUser user, string accessToken, string refreshToken)
    {
        UserId = user.Id;
        Username = user.UserName;
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }

    public Guid UserId { get; }
    public string AccessToken { get; }
    public string Username { get; }
    public string RefreshToken { get; }
}
