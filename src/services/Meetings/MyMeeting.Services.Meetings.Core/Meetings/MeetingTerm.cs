using BuildingBlocks.Core.Domain;
using BuildingBlocks.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings;

public class MeetingTerm : ValueObject
{
    public DateTime StartDate { get; }

    public DateTime EndDate { get; }

    public static MeetingTerm CreateNewBetweenDates(DateTime startDate, DateTime endDate)
    {
        return new MeetingTerm(startDate, endDate);
    }

    private MeetingTerm(DateTime startDate, DateTime endDate)
    {
        this.StartDate = startDate;
        this.EndDate = endDate;
    }

    internal bool IsAfterStart()
    {
        return SystemClock.Now > this.StartDate;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return StartDate;
        yield return EndDate;
    }
}
