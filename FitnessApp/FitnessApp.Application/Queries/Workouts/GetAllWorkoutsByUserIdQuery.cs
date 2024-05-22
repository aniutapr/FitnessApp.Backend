using MediatR;

namespace FitnessApp.Application.Queries.Workouts;

public class GetAllWorkoutsByUserIdQuery:IRequest<IEnumerable<WorkoutDto>>
{
	public Guid UserId { get; set; }
}