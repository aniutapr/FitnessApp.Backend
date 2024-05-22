using System;
using FitnessApp.Domain.Entities;
using MediatR;

namespace FitnessApp.Application.Commands.Workouts;

public class CreateWorkoutCommand:IRequest<Workout>
	{
    public WorkoutDto Workout { get; set; }
}



