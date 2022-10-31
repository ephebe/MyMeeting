using BuildingBlocks.Core.Persistence.EfCore;
using Microsoft.EntityFrameworkCore;
using MyMeeting.Services.Administration.Core.MeetingGroupProposals;
using MyMeeting.Services.Administration.Core.Members;
using MyMeeting.Services.Administration.Infrastructure.Domain.MeetingGroupProposals;
using MyMeeting.Services.Administration.Infrastructure.Domain.Members;

namespace MyMeeting.Services.Administration.Infrastructure;

public class AdministrationContext : EfDbContextBase
{
    internal DbSet<MeetingGroupProposal> MeetingGroupProposals { get; set; }
    internal DbSet<Member> Members { get; set; }

    public AdministrationContext(DbContextOptions<AdministrationContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
         => modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
   
}