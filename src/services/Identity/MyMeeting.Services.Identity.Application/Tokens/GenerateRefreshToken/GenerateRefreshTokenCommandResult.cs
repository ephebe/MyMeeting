using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Application.Tokens.GenerateRefreshToken;

public class GenerateRefreshTokenCommandResult
{
    public GenerateRefreshTokenCommandResult(RefreshTokenDto refreshTokenDto) 
    {
        this.RefreshToken = refreshTokenDto;
    }
    
    public RefreshTokenDto RefreshToken { get; }
}
