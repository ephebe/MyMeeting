using BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings;

public class MeetingLimits : ValueObject
{
    public int? AttendeesLimit { get; }

    public int GuestsLimit { get; }

    private MeetingLimits(int? attendeesLimit, int guestsLimit)
    {
        AttendeesLimit = attendeesLimit;
        GuestsLimit = guestsLimit;
    }

    public static MeetingLimits Create(int? attendeesLimit, int guestsLimit)
    {
        CheckRule(new MeetingAttendeesLimitCannotBeNegativeRule(attendeesLimit));

        CheckRule(new MeetingGuestsLimitCannotBeNegativeRule(guestsLimit));

        CheckRule(new MeetingAttendeesLimitMustBeGreaterThanGuestsLimitRule(attendeesLimit, guestsLimit));

        return new MeetingLimits(attendeesLimit, guestsLimit);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return AttendeesLimit;
        yield return GuestsLimit;
    }
}
