using AutoMapper;
using BuildingBlocks.Abstractions.CQRS.Events;
using BuildingBlocks.Abstractions.CQRS.Events.Internal;
using BuildingBlocks.Abstractions.Messaging;
using BuildingBlocks.Core.Mapping;
using MyMeeting.Services.Meetings.Core.MeetingGroupProposals.Events;
using MyMeeting.Services.Shared.Meetings.MeetingGroupProposals.Events.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Application.MeetingGroupProposals;

public class MeetingGroupProposalsIntegrationEventMapper : IIntegrationEventMapper
{
    private readonly IMapper _mapper;

    public MeetingGroupProposalsIntegrationEventMapper(IMapper mapper) 
    {
        _mapper = mapper;
    }
    public IIntegrationEvent? MapToIntegrationEvent(IDomainEvent domainEvent)
    {
        return domainEvent switch
        {
            MeetingGroupProposedDomainEvent e => _mapper.Map<MeetingGroupProposedIntegrationEvent>(e),
            _ => null
        };
    }

    public IReadOnlyList<IIntegrationEvent?>? MapToIntegrationEvents(IReadOnlyList<IDomainEvent> domainEvents)
    {
        return domainEvents.Select(MapToIntegrationEvent).ToList();
    }
}

public class MeetingGroupProposalsEventMapping : Profile
{
    public MeetingGroupProposalsEventMapping() 
    {
        CreateMap<MeetingGroupProposedDomainEvent, MeetingGroupProposedIntegrationEvent>()
            .ForMember(x => x.MeetingGroupProposalId, y => y.MapFrom(o => o.MeetingGroupProposalId.Value))
            .ReverseMap();
    }
}
