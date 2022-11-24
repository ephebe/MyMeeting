using BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.MeetingGroups;

public class MeetingGroupLocation : ValueObject
{
    public static MeetingGroupLocation CreateNew(string city, string countryCode)
    {
        return new MeetingGroupLocation(city, countryCode);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return City;
        yield return CountryCode;
    }

    public string City { get; }

    public string CountryCode { get; }

    private MeetingGroupLocation(string city, string countryCode)
    {
        City = city;
        CountryCode = countryCode;
    }
}
