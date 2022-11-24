using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMeeting.Services.Meetings.Core.MeetingGroupProposals;
using MyMeeting.Services.Meetings.Core.MeetingGroups;
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
        builder.ToTable("meeting_group_proposals");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(id => id.Value, id => id);

        builder.Property<string>("_name").HasColumnName("name");
        builder.Property<string>("_description").HasColumnName("description");
        builder.Property<MemberId>("_proposalUserId")
            .HasColumnName("proposal_user_id")
            .HasConversion(id => id.Value, id => id);

        builder.Property<DateTime>("_proposalDate").HasColumnName("proposal_date");

        builder.OwnsOne<MeetingGroupLocation>("_location", b =>
        {
            b.Property(p => p.City).HasColumnName("location_city");
            b.Property(p => p.CountryCode).HasColumnName("location_country_code");
        });

        builder.OwnsOne<MeetingGroupProposalStatus>("_status", b =>
        {
            b.Property(p => p.Value).HasColumnName("status_code");
        });
    }

}
