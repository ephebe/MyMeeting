using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMeeting.Services.Meetings.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Meeting.Infrastructure.Domain.Members;

public class MemberEntityTypeConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable("members", "meetings");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(id => id.Value, id => new MemberId(id));

        builder.Property<string>("_login").HasColumnName("login");
        builder.Property<string>("_email").HasColumnName("email");
        builder.Property<string>("_firstName").HasColumnName("first_name");
        builder.Property<string>("_lastName").HasColumnName("last_name");
        builder.Property<string>("_name").HasColumnName("name");
    }
}
