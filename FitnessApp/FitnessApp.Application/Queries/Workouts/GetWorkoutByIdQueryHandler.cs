using FitnessApp.Contracts.Interfaces.Repositories;
using FitnessApp.Domain.Entities;
using MediatR;

namespace FitnessApp.Application.Queries.Workouts
{
    public class GetWorkoutByIdQueryHandler : IRequestHandler<GetWorkoutByIdQuery, Workout>
    {
        private readonly IWorkoutRepository _workoutRepository;

        public GetWorkoutByIdQueryHandler(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public async Task<Workout> Handle(GetWorkoutByIdQuery request, CancellationToken cancellationToken)
        {
            var workout = await _workoutRepository.GetWorkoutByIdAsync(request.WorkoutId);

            if (workout == null)
            {
                return null;
            }

            return workout;
        }
    }
}
