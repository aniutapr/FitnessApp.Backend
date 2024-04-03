using System;
namespace FitnessApp.Application.Queries.Workouts
{
	public class GetWorkoutByIdQuery
	{
		public GetWorkoutByIdQuery()
		{
		}

        public Guid WorkoutId { get; set; }
    }
}

