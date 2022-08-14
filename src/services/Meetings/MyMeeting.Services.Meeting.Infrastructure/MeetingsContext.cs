using Microsoft.EntityFrameworkCore;
using MyMeeting.Services.Meetings.Core.MeetingGroupProposals;

namespace MyMeeting.Services.Meeting.Infrastructure
{
    public class MeetingsContext : DbContext
    {
        public DbSet<MeetingGroupProposal> MeetingGroupProposals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}