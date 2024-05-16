using MediatR;

namespace FitnessApp.Application.Commands.Workouts
{
    public class CloneWorkoutCommand : IRequest<WorkoutDto>
    {
        public Guid WorkoutId { get; set; }
    }
}
