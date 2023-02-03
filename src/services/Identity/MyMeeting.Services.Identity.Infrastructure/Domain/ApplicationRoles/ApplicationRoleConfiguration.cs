using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMeeting.Services.Identity.Core.ApplicationRoles;

namespace MyMeeting.Services.Identity.Infrastructure.Domain.ApplicationRoles;

internal class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.ToTable("asp_net_roles");

        builder.HasKey(x => x.Id);
        builder.Property(s => s.Id).ValueGeneratedOnAdd().HasColumnName("id");

        builder.Property<string>("ConcurrencyStamp").IsConcurrencyToken().HasColumnName("concurrency_stamp");

        builder.Property<string>(s => s.Name)
            .HasMaxLength(256)
            .HasColumnName("name");

        builder.Property<string>("NormalizedName")
            .HasMaxLength(256)
            .HasColumnName("normalized_name");

        builder.HasIndex("NormalizedName")
            .IsUnique()
            .HasDatabaseName("RoleNameIndex");
    }
}
