using System;
using FitnessApp.Domain.Entities;
using MediatR;

namespace FitnessApp.Application.Queries.Workouts
{
	public class GetWorkoutByIdQuery:IRequest<Workout>
	{
		public GetWorkoutByIdQuery()
		{
		}

        public Guid WorkoutId { get; set; }
    }
}

