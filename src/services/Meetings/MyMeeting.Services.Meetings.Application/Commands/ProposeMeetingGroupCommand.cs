using BuildingBlocks.Abstractions.CQRS.Commands;

namespace MyMeeting.Services.Meetings.Application.Commands;

public class ProposeMeetingGroupCommand : ICommand
{
    public ProposeMeetingGroupCommand(string name, string description, string locationCity, string locationCountryCode)
    {
        Name = name;
        Description = description;
        LocationCity = locationCity;
        LocationCountryCode = locationCountryCode;
    }

    public string Name { get; }

    public string Description { get; }

    public string LocationCity { get; }

    public string LocationCountryCode { get; }
}
