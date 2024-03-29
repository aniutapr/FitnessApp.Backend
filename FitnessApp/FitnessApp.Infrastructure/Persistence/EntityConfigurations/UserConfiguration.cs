using System;
using FitnessApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.Infrastructure.Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.HasIndex(u => u.Username).IsUnique();

        builder.HasIndex(u => u.Email).IsUnique();

        builder.HasMany(u => u.Roles)
               .WithMany(r => r.Users);

        builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.Property(u => u.PasswordHashed).IsRequired();
    }
}

