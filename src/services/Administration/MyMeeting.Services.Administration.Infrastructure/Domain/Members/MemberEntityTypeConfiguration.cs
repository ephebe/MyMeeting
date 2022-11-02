using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMeeting.Services.Administration.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Administration.Infrastructure.Domain.Members;

public class MemberEntityTypeConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable("members", "administration");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
           .HasConversion(id => id.Value, id => id);

        builder.Property<string>("_login").HasColumnName("login");
        builder.Property<string>("_email").HasColumnName("email");
        builder.Property<string>("_firstName").HasColumnName("first_name");
        builder.Property<string>("_lastName").HasColumnName("last_name");
        builder.Property<string>("_name").HasColumnName("name");
    }
}
