using System;
using FitnessApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.Infrastructure.Persistence.EntityConfigurations
{
	public class ExcersiseConfiguration : IEntityTypeConfiguration<Excersise>
    {
		public ExcersiseConfiguration()
		{
		}

        public void Configure(EntityTypeBuilder<Excersise> builder)
        {
            throw new NotImplementedException();
        }
    }
}

