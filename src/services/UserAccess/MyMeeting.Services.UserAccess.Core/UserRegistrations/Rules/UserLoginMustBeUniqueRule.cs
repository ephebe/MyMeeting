﻿using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.UserAccess.Core.UserRegistrations.Rules;

public class UserLoginMustBeUniqueRule : IBusinessRule
{
    private readonly IUsersCounter _usersCounter;
    private readonly string _login;

    internal UserLoginMustBeUniqueRule(IUsersCounter usersCounter, string login)
    {
        _usersCounter = usersCounter;
        _login = login;
    }

    public bool IsBroken() => _usersCounter.CountUsersWithLogin(_login) > 0;

    public string Message => "User Login must be unique";
}