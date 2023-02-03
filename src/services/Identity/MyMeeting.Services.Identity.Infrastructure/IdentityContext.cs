using BuildingBlocks.Abstractions.CQRS.Events.Internal;
using BuildingBlocks.Abstractions.Persistence;
using Humanizer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MyMeeting.Services.Identity.Core.ApplicationRoles;
using MyMeeting.Services.Identity.Core.ApplicationUsers;

namespace MyMeeting.Services.Identity.Infrastructure;

public class IdentityContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>,
    IDbFacadeResolver,
    IDomainEventContext
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    public IReadOnlyList<IDomainEvent> GetAllUncommittedEvents()
    {
        return new List<IDomainEvent>();
    }

    public void MarkUncommittedDomainEventAsCommitted()
    {
        // Method intentionally left empty.
    }
}