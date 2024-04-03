using MediatR;

namespace FitnessApp.Application.Excersises.Queries;

public class GetAllExcersisesQuery : IRequest<IEnumerable<ExcersiseDto>>
{
}
