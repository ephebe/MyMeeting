using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyMeeting.Services.Identity.Core.RefreshTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeeting.Services.Identity.Infrastructure.Domain.RefreshTokens;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("refresh_tokens");

        builder.Property<Guid>("Id")
            .ValueGeneratedOnAdd();
        builder.HasKey("Id");

        builder.HasIndex(x => new { x.Token, x.UserId }).IsUnique();

        builder.HasOne(rt => rt.ApplicationUser)
            .WithMany(au => au.RefreshTokens)
            .HasForeignKey(x => x.UserId);

        builder.Property(rt => rt.Token).HasMaxLength(100);
        builder.Property(rt => rt.CreatedAt);
        builder.Ignore(rt => rt.IsActive);
        builder.Ignore(rt => rt.IsExpired);
    }
}
