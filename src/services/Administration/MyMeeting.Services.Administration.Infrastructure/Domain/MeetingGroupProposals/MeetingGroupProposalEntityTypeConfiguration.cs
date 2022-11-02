using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMeeting.Services.Administration.Core.MeetingGroupProposals;
using MyMeeting.Services.Administration.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Infrastructure.Domain.MeetingGroupProposals;

internal class MeetingGroupProposalEntityTypeConfiguration : IEntityTypeConfiguration<MeetingGroupProposal>
{
    public void Configure(EntityTypeBuilder<MeetingGroupProposal> builder)
    {
        builder.ToTable("meeting_group_proposals", "administration");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
           .HasConversion(id => id.Value, id => id);

        builder.Property<string>("_name").HasColumnName("name");
        builder.Property<string>("_description").HasColumnName("description");
        builder.Property<UserId>("_proposalUserId")
            .HasColumnName("proposal_user_id")
            .HasConversion(id => id.Value, id => id); ;

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

        builder.OwnsOne<MeetingGroupProposalDecision>("_decision", b =>
        {
            b.Property(p => p.Code).HasColumnName("decision_code");
            b.Property(p => p.Date).HasColumnName("decision_date");
            b.Property(p => p.RejectReason).HasColumnName("decision_reject_reason");
            b.Property(p => p.UserId)
            .HasColumnName("decision_user_id")
            .HasConversion(id => id.Value, id => id);
        });
    }
}
