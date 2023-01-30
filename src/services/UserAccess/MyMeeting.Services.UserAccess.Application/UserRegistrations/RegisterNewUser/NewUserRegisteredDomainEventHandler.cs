using BuildingBlocks.Abstractions.CQRS.Events.Internal;
using MyMeeting.Services.UserAccess.Core.UserRegistrations.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.UserAccess.Application.UserRegistrations.RegisterNewUser;

public class NewUserRegisteredDomainEventHandler : IDomainEventHandler<NewUserRegisteredDomainEvent>
{
    public Task Handle(NewUserRegisteredDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
