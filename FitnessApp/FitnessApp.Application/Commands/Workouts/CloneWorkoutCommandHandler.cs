using FitnessApp.Contracts.Interfaces.Repositories;
using MediatR;


namespace FitnessApp.Application.Commands.Workouts
{
    public class CloneWorkoutCommandHandler : IRequestHandler<CloneWorkoutCommand, WorkoutDto>
    {
        private readonly IWorkoutRepository _workoutRepository;

        public CloneWorkoutCommandHandler(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public async Task<WorkoutDto> Handle(CloneWorkoutCommand request, CancellationToken cancellationToken)
        {
            var existingWorkout = await _workoutRepository.GetWorkoutByIdAsync(request.WorkoutId);

            if (existingWorkout == null)
            {
                return null; // Workout not found
            }

            var clonedWorkout = _workoutRepository.CloneWorkout(existingWorkout);

            return clonedWorkout.ToDto();
        }
    }
}
