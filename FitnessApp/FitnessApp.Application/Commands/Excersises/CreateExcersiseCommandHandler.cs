using FitnessApp.Application.Mapping;
using FitnessApp.Contracts.Interfaces.Repositories;
using FitnessApp.Domain.Entities;
using MediatR;

namespace FitnessApp.Application.Commands;

public class CreateExcersiseCommandHandler : IRequestHandler<CreateExcersiseCommand, Excersise>
{
    private readonly IExcersiseRepository _excersiseRepository;

    public CreateExcersiseCommandHandler(IExcersiseRepository excersiseRepository)
    {
        _excersiseRepository = excersiseRepository;
    }

    public async Task<Excersise> Handle(CreateExcersiseCommand request, CancellationToken cancellationToken)
    {
        return await _excersiseRepository.AddExcersiseAsync(request.ExcersiseDto.ToEntity());
    }
}