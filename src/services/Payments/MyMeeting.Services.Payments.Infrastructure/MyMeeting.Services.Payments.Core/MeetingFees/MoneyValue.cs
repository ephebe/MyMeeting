using BuildingBlocks.Core.Domain;
using MyMeeting.Services.Payments.Core.MeetingFees.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Payments.Core.MeetingFees;

public class MoneyValue : ValueObject
{
    public decimal Value { get; }

    public string Currency { get; }

    private MoneyValue(decimal value, string currency)
    {
        this.Value = value;
        this.Currency = currency;
    }

    public static MoneyValue Of(decimal value, string currency)
    {
        CheckRule(new ValueOfMoneyMustNotBeNegativeRule(value));

        return new MoneyValue(value, currency);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return Currency;
    }

    public static bool operator >(decimal left, MoneyValue right) => left > right.Value;

    public static bool operator <(decimal left, MoneyValue right) => left < right.Value;

    public static bool operator >=(decimal left, MoneyValue right) => left >= right.Value;

    public static bool operator <=(decimal left, MoneyValue right) => left <= right.Value;

    public static bool operator >(MoneyValue left, decimal right) => left.Value > right;

    public static bool operator <(MoneyValue left, decimal right) => left.Value < right;

    public static bool operator >=(MoneyValue left, decimal right) => left.Value >= right;

    public static bool operator <=(MoneyValue left, decimal right) => left.Value <= right;

    public static MoneyValue operator -(MoneyValue left, MoneyValue right)
    {
        CheckRule(new MoneyMustHaveTheSameCurrencyRule(left, right));

        return Of(left.Value - right.Value, left.Currency);
    }
}
