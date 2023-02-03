using BuildingBlocks.Core.Exception.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Application.ApplicationUsers.Exceptions;

public class EmailNotConfirmedException : BadRequestException
{
    public EmailNotConfirmedException(string email) : base($"Email not confirmed for email address `{email}`")
    {
        Email = email;
    }

    public string Email { get; }
}
