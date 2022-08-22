using BuildingBlocks.Core.Persistence.EfCore;
using Microsoft.EntityFrameworkCore;
using MyMeeting.Services.Meetings.Core.MeetingGroupProposals;

namespace MyMeeting.Services.Meeting.Infrastructure
{
    public class MeetingsContext : EfDbContextBase
    {
        public DbSet<MeetingGroupProposal> MeetingGroupProposals { get; set; }

        public MeetingsContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}