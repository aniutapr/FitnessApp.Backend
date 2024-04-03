using MediatR;

namespace FitnessApp.Application.Commands.LogExcersise
{
    public class LogExerciseCommand:IRequest<Domain.Entities.LogExcersise>
	{
        public Guid WorkoutId { get; set; }
        public LogExcersiseDto LogExersiseDto { get; set; }
    }
}