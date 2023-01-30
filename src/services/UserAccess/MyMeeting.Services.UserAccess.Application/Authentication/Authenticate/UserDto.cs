﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.UserAccess.Application.Authentication.Authenticate;

public class UserDto
{
    public Guid Id { get; set; }

    public string Login { get; set; }

    public bool IsActive { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public List<Claim> Claims { get; set; }

    public string Password { get; set; }
}
