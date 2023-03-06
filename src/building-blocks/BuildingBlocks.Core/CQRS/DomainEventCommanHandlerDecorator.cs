using BuildingBlocks.Abstractions.CQRS.Commands;
using BuildingBlocks.Abstractions.CQRS.Events;
using BuildingBlocks.Abstractions.CQRS.Events.Internal;
using MediatR;

namespace BuildingBlocks.Core.CQRS;

public class DomainEventCommanHandlerDecorator<T> : ICommandHandler<T>
        where T : ICommand
{
    private readonly ICommandHandler<T> _decorated;
    private readonly IDomainEventsAccessor _domainEventsAccessor;
    private readonly IDomainEventPublisher _domainEventPublisher;

    public DomainEventCommanHandlerDecorator(
        ICommandHandler<T> decorated,
        IDomainEventsAccessor domainEventsAccessor,
        IDomainEventPublisher domainEventPublisher)
    {
        _decorated = decorated;
        _domainEventsAccessor = domainEventsAccessor;
        _domainEventPublisher = domainEventPublisher;
    }

    public async Task<Unit> Handle(T command, CancellationToken cancellationToken)
    {
        await this._decorated.Handle(command, cancellationToken);

        var domainEvents = _domainEventsAccessor.UnCommittedDomainEvents;
        await _domainEventPublisher.PublishAsync(domainEvents.ToArray(), cancellationToken);

        return Unit.Value;
    }
}
