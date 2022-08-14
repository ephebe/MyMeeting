using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMeeting.Services.Meetings.Core.MeetingGroupProposals;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meeting.Infrastructure.Domain.MeetingGroupProposals;

public class MeetingGroupProposalEntityTypeConfiguration : IEntityTypeConfiguration<MeetingGroupProposal>
{
    public void Configure(EntityTypeBuilder<MeetingGroupProposal> builder)
    {
        builder.ToTable("MeetingGroupProposals", "meetings");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);

        builder.Property<string>("_name").HasColumnName("Name");
        builder.Property<string>("_description").HasColumnName("Description");
        builder.Property<MemberId>("_proposalUserId").HasColumnName("ProposalUserId");
        builder.Property<DateTime>("_proposalDate").HasColumnName("ProposalDate");

        builder.OwnsOne<MeetingGroupLocation>("_location", b =>
        {
            b.Property(p => p.City).HasColumnName("LocationCity");
            b.Property(p => p.CountryCode).HasColumnName("LocationCountryCode");
        });

        builder.OwnsOne<MeetingGroupProposalStatus>("_status", b =>
        {
            b.Property(p => p.Value).HasColumnName("StatusCode");
        });
    }

}
