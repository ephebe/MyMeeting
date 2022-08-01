using Ardalis.GuardClauses;
using BuildingBlocks.Core.Domain.Exceptions;
using BuildingBlocks.Core.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Core.Domain.ValueObjects;

public record Currency
{
    public string Value { get; private set; }

    public static Currency? Null => null;

    public static Currency Create(string value)
    {
        return new Currency
        {
            Value = Guard.Against.InvalidCurrency(value, new DomainException($"Currency {value} is invalid."))
        };
    }

    public static implicit operator Currency?(string? value) => value == null ? null : Create(value);

    public static implicit operator string?(Currency? value) => value?.Value;
}
