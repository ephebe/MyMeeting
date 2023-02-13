using MyMeeting.Services.Identity.Core.Users;

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
