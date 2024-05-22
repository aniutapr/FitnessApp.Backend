using System;
using FitnessApp.Domain.Entities;
using MediatR;

namespace FitnessApp.Application.Commands.Workouts
{
	public class UpdateWorkoutCommand:IRequest<Unit>
	{
        public Workout Workout { get; set; }
    }
}

