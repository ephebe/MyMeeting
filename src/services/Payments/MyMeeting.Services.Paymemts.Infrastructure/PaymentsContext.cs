using BuildingBlocks.Core.Persistence.EfCore;
using Microsoft.EntityFrameworkCore;

namespace MyMeeting.Services.Paymemts.Infrastructure;

public class PaymentsContext : EfDbContextBase
{
    public PaymentsContext(DbContextOptions<PaymentsContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
}