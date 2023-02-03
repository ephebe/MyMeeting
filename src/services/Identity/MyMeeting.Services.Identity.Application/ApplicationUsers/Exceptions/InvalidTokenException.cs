using BuildingBlocks.Core.Exception.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Application.ApplicationUsers.Exceptions;

public class InvalidTokenException : BadRequestException
{
    public InvalidTokenException(ClaimsPrincipal? claimsPrincipal) : base("access_token is invalid!")
    {
    }
}
