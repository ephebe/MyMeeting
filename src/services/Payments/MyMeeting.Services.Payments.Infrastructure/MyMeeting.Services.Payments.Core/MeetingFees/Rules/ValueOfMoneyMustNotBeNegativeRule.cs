using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Payments.Core.MeetingFees.Rules;

public class ValueOfMoneyMustNotBeNegativeRule : IBusinessRule
{
    private readonly decimal _value;

    public ValueOfMoneyMustNotBeNegativeRule(decimal value)
    {
        _value = value;
    }

    public bool IsBroken() => _value < 0;

    public string Message => "Value of money must not be negative.";
}
