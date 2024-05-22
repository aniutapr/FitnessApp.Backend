using FitnessApp.Contracts.Interfaces.Repositories;
using FitnessApp.Domain.Entities;
using MediatR;

namespace FitnessApp.Application.Commands.Workouts
{
    public class CreateWorkoutCommandHandler : IRequestHandler<CreateWorkoutCommand, Workout>
	{
        private readonly IWorkoutRepository _workoutRepository;
		public CreateWorkoutCommandHandler(IWorkoutRepository workoutRepository)
		{
            _workoutRepository = workoutRepository;
		}

        public async Task<Workout> Handle(CreateWorkoutCommand request, CancellationToken cancellationToken)
        {
            return await _workoutRepository.AddWorkoutAsync(request.Workout.ToEntity(new Guid()));
        }
    }
}