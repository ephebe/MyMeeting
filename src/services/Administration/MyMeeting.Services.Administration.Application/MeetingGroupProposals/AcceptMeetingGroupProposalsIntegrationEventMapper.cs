using AutoMapper;
using BuildingBlocks.Abstractions.CQRS.Events;
using BuildingBlocks.Abstractions.CQRS.Events.Internal;
using BuildingBlocks.Abstractions.Messaging;
using MyMeeting.Services.Administration.Core.MeetingGroupProposals.Events;
using MyMeeting.Services.Shared.Administration.MeetingGroupProposals.Events.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Application.MeetingGroupProposals;

public class AcceptMeetingGroupProposalsIntegrationEventMapper : IIntegrationEventMapper
{
    private readonly IMapper _mapper;

    public AcceptMeetingGroupProposalsIntegrationEventMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public IIntegrationEvent? MapToIntegrationEvent(IDomainEvent domainEvent)
    {
        return domainEvent switch
        {
            MeetingGroupProposalAcceptedDomainEvent e => _mapper.Map<MeetingGroupProposalAcceptedIntegrationEvent>(e),
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
        CreateMap<MeetingGroupProposalAcceptedDomainEvent, MeetingGroupProposalAcceptedIntegrationEvent>()
            .ForMember(target => target.MeetingGroupProposalId, from => from.MapFrom(o => o.MeetingGroupProposalId.Value));
    }
}
