using AutoMapper;
using BuildingBlocks.Abstractions.CQRS.Events;
using BuildingBlocks.Abstractions.CQRS.Events.Internal;
using BuildingBlocks.Abstractions.Messaging;
using MyMeeting.Services.Meetings.Core.MeetingGroupProposals.Events;
using MyMeeting.Services.Meetings.Core.Meetings.Events;
using MyMeeting.Services.Shared.Meetings.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meetings.Application.Meetings;

public class MeetingsIntegrationEventMapper : IIntegrationEventMapper
{
    private readonly IMapper _mapper;

    public MeetingsIntegrationEventMapper(IMapper mapper)
    {
        _mapper = mapper;
    }
    public IIntegrationEvent? MapToIntegrationEvent(IDomainEvent domainEvent)
    {
        return domainEvent switch
        {
            MeetingAttendeeAddedDomainEvent e => _mapper.Map<MeetingAttendeeAddedIntegrationEvent>(e),
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
        CreateMap<MeetingAttendeeAddedDomainEvent, MeetingAttendeeAddedIntegrationEvent>()
            .ForMember(target => target.MeetingId, from => from.MapFrom(o => o.MeetingId.Value))
            .ForMember(target => target.AttendeeId, from => from.MapFrom(o => o.AttendeeId.Value))
            .ForMember(target => target.FeeValue, from => from.MapFrom(o => o.FeeValue))
            .ForMember(target => target.FeeCurrency, from => from.MapFrom(o => o.FeeCurrency));
    }
}

