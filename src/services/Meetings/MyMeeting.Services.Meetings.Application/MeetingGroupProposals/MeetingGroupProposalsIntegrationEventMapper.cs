using AutoMapper;
using BuildingBlocks.Abstractions.CQRS.Events;
using BuildingBlocks.Abstractions.CQRS.Events.Internal;
using BuildingBlocks.Abstractions.Messaging;
using BuildingBlocks.Core.Mapping;
using MyMeeting.Services.Meetings.Core.MeetingGroupProposals.Events;
using MyMeeting.Services.Shared.Meetings.IntegrationEvents;
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
            .ForMember(target => target.MeetingGroupProposalId, from => from.MapFrom(o => o.MeetingGroupProposalId.Value))
            .ForMember(target => target.Name, from => from.MapFrom(o => o.Name))
            .ForMember(target => target.LocationCity, from => from.MapFrom(o => o.LocationCity))
            .ForMember(target => target.LocationCountryCode, from => from.MapFrom(o => o.LocationCountryCode))
            .ForMember(target => target.ProposalUserId, from => from.MapFrom(o => o.ProposalUserId.Value))
            .ForMember(target => target.ProposalDate, from => from.MapFrom(o => o.ProposalDate));
    }
}
