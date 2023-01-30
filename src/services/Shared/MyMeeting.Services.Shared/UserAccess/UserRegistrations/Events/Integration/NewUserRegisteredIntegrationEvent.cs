using BuildingBlocks.Core.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Shared.UserAccess.UserRegistrations.Events.Integration;

public record NewUserRegisteredIntegrationEvent : IntegrationEvent
{
    public Guid UserId { get; set; }

    public string Login { get; set; }

    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Name { get; set; }
}
