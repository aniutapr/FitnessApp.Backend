using System;
using MediatR;

namespace FitnessApp.Application.Commands.LogExcersise
{
	public class DeleteLogExerciseCommand:IRequest<Unit>
	{
        public Guid LogId { get; set; }
    }
}

