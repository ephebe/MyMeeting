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

        // https://andrewlock.net/customising-asp-net-core-identity-ef-core-naming-conventions-for-postgresql/
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            // Replace table names
            entity.SetTableName(entity.GetTableName()?.Underscore());

            var ecommerceObjectIdentifier =
                StoreObjectIdentifier.Table(entity.GetTableName()?.Underscore()!, entity.GetSchema());

            // Replace column names
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnName(ecommerceObjectIdentifier)?.Underscore());
            }

            foreach (var key in entity.GetKeys())
            {
                key.SetName(key.GetName()?.Underscore());
            }

            foreach (var key in entity.GetForeignKeys())
            {
                key.SetConstraintName(key.GetConstraintName()?.Underscore());
            }
        }
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