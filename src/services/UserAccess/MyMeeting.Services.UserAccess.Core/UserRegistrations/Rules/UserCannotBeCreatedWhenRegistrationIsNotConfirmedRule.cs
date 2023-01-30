using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.UserAccess.Core.UserRegistrations.Rules;

public class UserCannotBeCreatedWhenRegistrationIsNotConfirmedRule : IBusinessRule
{
    private readonly UserRegistrationStatus _actualRegistrationStatus;

    internal UserCannotBeCreatedWhenRegistrationIsNotConfirmedRule(UserRegistrationStatus actualRegistrationStatus)
    {
        this._actualRegistrationStatus = actualRegistrationStatus;
    }

    public bool IsBroken() => _actualRegistrationStatus != UserRegistrationStatus.Confirmed;

    public string Message => "User cannot be created when registration is not confirmed";
}
