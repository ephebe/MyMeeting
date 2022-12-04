using BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings;

public class Term : ValueObject
{
    public static Term NoTerm => new Term(null, null);

    public DateTime? StartDate { get; }

    public DateTime? EndDate { get; }

    public static Term CreateNewBetweenDates(DateTime? startDate, DateTime? endDate)
    {
        return new Term(startDate, endDate);
    }

    private Term(DateTime? startDate, DateTime? endDate)
    {
        this.StartDate = startDate;
        this.EndDate = endDate;
    }

    internal bool IsInTerm(DateTime date)
    {
        var left = !this.StartDate.HasValue || this.StartDate.Value <= date;

        var right = !this.EndDate.HasValue || this.EndDate.Value >= date;

        return left && right;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return StartDate;
        yield return EndDate;
    }
}
