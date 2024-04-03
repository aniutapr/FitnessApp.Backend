using System;

namespace FitnessApp.Application.Commands.LogExcersise
{
	public class UpdateLogExerciseCommand
	{
		public UpdateLogExerciseCommand()
		{
		}

        public Domain.Entities.LogExcersise LogExercise { get; set; }
    }
}

