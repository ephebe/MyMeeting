using BuildingBlocks.Core.Exception.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Application.ApplicationUsers.Exceptions;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(string emailOrUserName) : base($"User with email or username: '{emailOrUserName}' not found.")
    {
    }

    public UserNotFoundException(Guid id) : base($"User with id: '{id}' not found.")
    {
    }
}
