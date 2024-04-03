using System;
using MediatR;

namespace FitnessApp.Application.Commands.Workouts
{
	public class DeleteWorkoutCommand:IRequest<Unit>
	{
        public Guid WorkoutId { get; set; }
    }
}