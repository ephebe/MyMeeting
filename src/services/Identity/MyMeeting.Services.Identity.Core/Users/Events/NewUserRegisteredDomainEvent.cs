using BuildingBlocks.Core.CQRS.Events.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Core.Users.Events;

public record NewUserRegisteredDomainEvent : DomainEvent
{
    public ApplicationUserId ApplicationUserId { get; }
    public string Login { get; }

    public string Email { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public string Name { get; }

    public DateTime RegisterDate { get; }

    public string ConfirmLink { get; }

    public NewUserRegisteredDomainEvent(
        ApplicationUserId applicationUserId,
        string login,
        string email,
        string firstName,
        string lastName,
        string name,
        DateTime registerDate,
        string confirmLink)
    {
        ApplicationUserId = applicationUserId;
        Login = login;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Name = name;
        RegisterDate = registerDate;
        ConfirmLink = confirmLink;
    }
}
