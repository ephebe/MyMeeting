using BuildingBlocks.Core.Exception.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Application.Users.Exceptions;

public class RegisterIdentityUserException : BadRequestException
{
    public RegisterIdentityUserException(string error) : base(error)
    {
    }
}

