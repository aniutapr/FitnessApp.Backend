using System;
using FitnessApp.Contracts.Interfaces.Repositories;
using MediatR;

namespace FitnessApp.Application.Commands.Workouts
{
	public class UpdateWorkoutCommandHandler:IRequestHandler<UpdateWorkoutCommand, Unit>
	{
        private readonly IWorkoutRepository _workoutRepository;
		public UpdateWorkoutCommandHandler(IWorkoutRepository workoutRepository)
		{
            _workoutRepository = workoutRepository;
		}

        public async Task<Unit> Handle(UpdateWorkoutCommand request, CancellationToken cancellationToken)
        {
            await _workoutRepository.UpdateWorkoutAsync(request.Workout);
            return Unit.Value;
        }
    }
}