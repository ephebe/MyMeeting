using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMeeting.Services.Identity.Core.Users;

namespace MyMeeting.Services.Identity.Infrastructure.Domain.ApplicationUsers;

internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

        builder.Property<int>("AccessFailedCount")
            .HasColumnType("integer")
            .HasColumnName("access_failed_count");

        builder.Property<string>("ConcurrencyStamp")
            .IsConcurrencyToken()
            .HasColumnType("text")
            .HasColumnName("concurrency_stamp");

        builder.Property<DateTime>("CreatedAt")
            .ValueGeneratedOnAdd()
            .HasColumnType("timestamp with time zone")
            .HasColumnName("created_at")
            .HasDefaultValueSql("now()");

        builder.Property<string>("Email")
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("character varying(50)")
            .HasColumnName("email");

        builder.Property<bool>("EmailConfirmed")
            .HasColumnType("boolean")
            .HasColumnName("email_confirmed");

        builder.Property<string>("FirstName")
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("character varying(100)")
            .HasColumnName("first_name");

        builder.Property<DateTime?>("LastLoggedInAt")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("last_logged_in_at");

        builder.Property<string>("LastName")
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("character varying(100)")
            .HasColumnName("last_name");

        builder.Property<bool>("LockoutEnabled")
            .HasColumnType("boolean")
            .HasColumnName("lockout_enabled");

        builder.Property<DateTimeOffset?>("LockoutEnd")
            .HasColumnType("timestamp with time zone")
            .HasColumnName("lockout_end");

        builder.Property<string>("NormalizedEmail")
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("character varying(50)")
            .HasColumnName("normalized_email");

        builder.Property<string>("NormalizedUserName")
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("character varying(50)")
            .HasColumnName("normalized_user_name");

        builder.Property<string>("PasswordHash")
            .HasColumnType("text")
            .HasColumnName("password_hash");

        builder.Property<string>("PhoneNumber")
            .HasMaxLength(15)
            .HasColumnType("character varying(15)")
            .HasColumnName("phone_number");

        builder.Property<bool>("PhoneNumberConfirmed")
            .HasColumnType("boolean")
            .HasColumnName("phone_number_confirmed");

        builder.Property<string>("SecurityStamp")
            .HasColumnType("text")
            .HasColumnName("security_stamp");

        builder.Property<bool>("TwoFactorEnabled")
            .HasColumnType("boolean")
            .HasColumnName("two_factor_enabled");

        builder.Property<string>("UserName")
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("character varying(50)")
            .HasColumnName("user_name");

        builder.Property<string>("UserState")
            .IsRequired()
            .ValueGeneratedOnAdd()
            .HasColumnType("text")
            .HasDefaultValue("Active")
            .HasColumnName("user_state");

        builder.HasKey("Id")
            .HasName("pk_asp_net_users");

        builder.HasIndex("Email")
            .IsUnique()
            .HasDatabaseName("ix_asp_net_users_email");

        builder.HasIndex("NormalizedEmail")
            .IsUnique()
            .HasDatabaseName("EmailIndex");

        builder.HasIndex("NormalizedUserName")
            .IsUnique()
            .HasDatabaseName("UserNameIndex");

       
        builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(100).IsRequired();
        builder.Property(x => x.UserName).HasMaxLength(50).IsRequired();
        builder.Property(x => x.NormalizedUserName).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
        builder.Property(x => x.NormalizedEmail).HasMaxLength(50).IsRequired();
        builder.Property(x => x.PhoneNumber).HasMaxLength(15).IsRequired(false);

        builder.Property(x => x.CreatedAt).HasDefaultValueSql("now()");

        builder.Property(x => x.UserState)
            .HasDefaultValue(UserState.Active)
            .HasConversion(x => x.ToString(), x => (UserState)Enum.Parse(typeof(UserState), x));

        builder.HasIndex(x => x.Email).IsUnique();
        builder.HasIndex(x => x.NormalizedEmail).IsUnique();

        builder.ToTable("asp_net_users", (string)null);
    }
}
