using AutoMapper;
using BuildingBlocks.Abstractions.CQRS.Events;
using BuildingBlocks.Abstractions.CQRS.Events.Internal;
using BuildingBlocks.Abstractions.Messaging;
using MyMeeting.Services.Shared.Meetings.MeetingGroupProposals.Events.Integration;
using MyMeeting.Services.Shared.UserAccess.UserRegistrations.Events.Integration;
using MyMeeting.Services.UserAccess.Core.UserRegistrations.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.UserAccess.Application.UserRegistrations;

public class UserRegistrationsIntegrationEventMapper : IIntegrationEventMapper
{
    private readonly IMapper _mapper;

    public UserRegistrationsIntegrationEventMapper(IMapper mapper)
    {
        _mapper = mapper;
    }
    public IIntegrationEvent? MapToIntegrationEvent(IDomainEvent domainEvent)
    {
        return domainEvent switch
        {
            NewUserRegisteredDomainEvent e => _mapper.Map<NewUserRegisteredIntegrationEvent>(e),
            _ => null
        };
    }

    public IReadOnlyList<IIntegrationEvent?>? MapToIntegrationEvents(IReadOnlyList<IDomainEvent> domainEvents)
    {
        return domainEvents.Select(MapToIntegrationEvent).ToList();
    }
}

public class UserRegistrationsEventMapping : Profile
{
    public UserRegistrationsEventMapping()
    {
        CreateMap<NewUserRegisteredDomainEvent, NewUserRegisteredIntegrationEvent>()
            .ForMember(target => target.UserId, from => from.MapFrom(o => o.UserRegistrationId.Value))
            .ForMember(target => target.Login, from => from.MapFrom(o => o.Login))
            .ForMember(target => target.Email, from => from.MapFrom(o => o.Email))
            .ForMember(target => target.FirstName, from => from.MapFrom(o => o.FirstName))
            .ForMember(target => target.LastName, from => from.MapFrom(o => o.LastName))
            .ForMember(target => target.Name, from => from.MapFrom(o => o.Name));
    }
}
