using BuildingBlocks.Core.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Shared.UserAccess.UserRegistrations.Events.Integration;

public record NewUserRegisteredIntegrationEvent : IntegrationEvent
{
    public Guid UserId { get; }
    public string Login { get; }

    public string Email { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public string Name { get; }

    public DateTime RegisterDate { get; }

    public NewUserRegisteredIntegrationEvent(
        Guid userId,
        string login,
        string email,
        string firstName,
        string lastName,
        string name,
        DateTime registerDate)
    {
        UserId = userId;
        Login = login;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Name = name;
        RegisterDate = registerDate;
    }
}


