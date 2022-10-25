using BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Core.MeetingGroupProposals;

public class MeetingGroupLocation : ValueObject
{
    private MeetingGroupLocation(string city, string countryCode)
    {
        City = city;
        CountryCode = countryCode;
    }

    public string City { get; }

    public string CountryCode { get; }

    public static MeetingGroupLocation Create(string city, string countryCode)
    {
        return new MeetingGroupLocation(city, countryCode);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return City;
        yield return CountryCode;
    }
}
