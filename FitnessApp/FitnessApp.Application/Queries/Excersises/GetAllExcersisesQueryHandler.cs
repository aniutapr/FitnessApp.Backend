using FitnessApp.Application.Excersises.Queries;
using FitnessApp.Application.Mapping;
using FitnessApp.Contracts.Interfaces.Repositories;
using FitnessApp.Domain.Entities;
using MediatR;

namespace FitnessApp.Application.Queries;

public class GetAllExcersisesQueryHandler : IRequestHandler<GetAllExcersisesQuery, IEnumerable<ExcersiseDto>>
{
    private readonly IExcersiseRepository _excersiseRepository;

    public GetAllExcersisesQueryHandler(IExcersiseRepository excersiseRepository)
    {
        _excersiseRepository = excersiseRepository;
    }

    public async Task<IEnumerable<ExcersiseDto>> Handle(GetAllExcersisesQuery request, CancellationToken cancellationToken)
    {
        var excersises = await _excersiseRepository.GetAllExcersisesAsync();
        var exDto = new List<ExcersiseDto>();
        foreach (Excersise ex in excersises)
        {
            exDto.Add(ex.ToDto());
        }
        return exDto;
    }
}