using System;
namespace FitnessApp.Application.Queries.LogExcersise
{
	public class GetAllLogExercisesByWorkoutIdQuery
	{
		public GetAllLogExercisesByWorkoutIdQuery()
		{
		}

        public Guid WorkoutId { get; set; }
    }
}

