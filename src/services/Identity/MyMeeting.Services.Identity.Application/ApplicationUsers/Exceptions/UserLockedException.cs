using BuildingBlocks.Core.Exception.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Application.ApplicationUsers.Exceptions;

public class UserLockedException : BadRequestException
{
    public UserLockedException(string userId) : base($"userId '{userId}' has been locked.")
    {
    }
}
