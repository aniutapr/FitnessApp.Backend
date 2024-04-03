using FitnessApp.Contracts.Interfaces.Repositories;
using MediatR;

namespace FitnessApp.Application.Commands.Workouts
{
    public class DeleteWorkoutCommandHandler:IRequestHandler<DeleteWorkoutCommand, Unit>
	{
        private readonly IWorkoutRepository _workoutRepository;
		public DeleteWorkoutCommandHandler(IWorkoutRepository workoutRepository)
		{
            _workoutRepository = workoutRepository;
		}

        public async Task<Unit> Handle(DeleteWorkoutCommand request, CancellationToken cancellationToken)
        {
            await _workoutRepository.DeleteWorkoutAsync(request.WorkoutId);
            return Unit.Value;
        }
    }
}