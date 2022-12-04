using BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings;

public class MoneyValue : ValueObject
{
    public static MoneyValue Undefined => new MoneyValue(null, null);

    public decimal? Value { get; }

    public string Currency { get; }

    public static MoneyValue Of(decimal value, string currency)
    {
        return new MoneyValue(value, currency);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return Currency;
    }

    private MoneyValue(decimal? value, string currency)
    {
        this.Value = value;
        this.Currency = currency;
    }

    public static MoneyValue operator *(int left, MoneyValue right)
    {
        return new MoneyValue(right.Value * left, right.Currency);
    }
}
