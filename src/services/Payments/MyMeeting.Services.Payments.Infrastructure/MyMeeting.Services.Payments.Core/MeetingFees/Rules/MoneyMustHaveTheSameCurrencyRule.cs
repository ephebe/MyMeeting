using BuildingBlocks.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Payments.Core.MeetingFees.Rules;

public class MoneyMustHaveTheSameCurrencyRule : IBusinessRule
{
    private readonly MoneyValue _left;

    private readonly MoneyValue _right;

    public MoneyMustHaveTheSameCurrencyRule(MoneyValue left, MoneyValue right)
    {
        _left = left;
        _right = right;
    }

    public bool IsBroken() => _left.Currency != _right.Currency;

    public string Message => "Currency of money must be the same.";
}
