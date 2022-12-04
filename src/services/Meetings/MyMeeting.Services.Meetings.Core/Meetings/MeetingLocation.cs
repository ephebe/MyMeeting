using BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Core.Meetings;

public class MeetingLocation : ValueObject
{
    public static MeetingLocation CreateNew(string name, string address, string postalCode, string city)
    {
        return new MeetingLocation(name, address, postalCode, city);
    }

    private MeetingLocation(string name, string address, string postalCode, string city)
    {
        Name = name;
        Address = address;
        PostalCode = postalCode;
        City = city;
    }

    public string Name { get; }

    public string Address { get; }

    public string PostalCode { get; }

    public string City { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return PostalCode;
        yield return City;
    }
}
