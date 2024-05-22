using System;
using FitnessApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.Infrastructure.Persistence.EntityConfigurations
{
	public class WorkoutGoalConfiguration : IEntityTypeConfiguration<WorkoutGoal>
    {
		public WorkoutGoalConfiguration()
		{
		}

        public void Configure(EntityTypeBuilder<WorkoutGoal> builder)
        {
            throw new NotImplementedException();
        }
    }
}