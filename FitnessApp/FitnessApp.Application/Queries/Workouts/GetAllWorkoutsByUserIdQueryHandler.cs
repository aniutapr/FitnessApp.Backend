using FitnessApp.Contracts.Interfaces.Repositories;
using FitnessApp.Domain.Entities;
using MediatR;

namespace FitnessApp.Application.Queries.Workouts
{
    public class GetAllWorkoutsByUserIdQueryHandler:IRequestHandler<GetAllWorkoutsByUserIdQuery, IEnumerable<WorkoutDto>>
	{
        private readonly IWorkoutRepository _workoutRepository;
		public GetAllWorkoutsByUserIdQueryHandler(IWorkoutRepository workoutRepository)
		{
            _workoutRepository = workoutRepository;
		}

        public async Task<IEnumerable<WorkoutDto>> Handle(GetAllWorkoutsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var workouts=await _workoutRepository.GetWorkoutsByUserIdAsync(request.UserId);
            var workoutsDto = new List<WorkoutDto>();

            foreach (Workout workout in workouts)
            {
                workoutsDto.Add(workout.ToDto());

            }
            return workoutsDto;
        }
    }
}