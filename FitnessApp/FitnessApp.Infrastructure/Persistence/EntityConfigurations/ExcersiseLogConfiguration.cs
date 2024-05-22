using System;
using FitnessApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.Infrastructure.Persistence.EntityConfigurations;

public class LogExcersiseConfiguration : IEntityTypeConfiguration<LogExcersise>
{
    public void Configure(EntityTypeBuilder<LogExcersise> builder)
    {
        builder.ToTable("LogExcersises");

        builder.HasKey(e => e.LogId);

        builder.Property(e => e.ExcersiseId)
               .IsRequired();

        builder.Property(e => e.WorkoutId)
               .IsRequired();
    }
}