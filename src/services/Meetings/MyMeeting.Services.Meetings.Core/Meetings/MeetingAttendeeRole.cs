using BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings;

public class MeetingAttendeeRole : ValueObject
{
    public static MeetingAttendeeRole Host => new MeetingAttendeeRole("Host");

    public static MeetingAttendeeRole Attendee => new MeetingAttendeeRole("Attendee");

    public string Value { get; }

    private MeetingAttendeeRole(string value)
    {
        this.Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
