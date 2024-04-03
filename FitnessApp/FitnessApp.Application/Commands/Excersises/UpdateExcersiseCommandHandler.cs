using FitnessApp.Contracts.Interfaces.Repositories;
using FitnessApp.Domain.Entities;
using MediatR;

namespace FitnessApp.Application.Commands.Excersises
{
    public class UpdateExcersiseCommandHandler:IRequestHandler<UpdateExcersiseCommand, Excersise>
	{
        private readonly IExcersiseRepository _excersiseRepository;

        public UpdateExcersiseCommandHandler(IExcersiseRepository excersiseRepository)
        {
            _excersiseRepository = excersiseRepository;
        }

        public async Task<Excersise> Handle(UpdateExcersiseCommand request, CancellationToken cancellationToken)
        {
            return await _excersiseRepository.UpdateExcersiseAsync(request.Excersise); ;
        }
    }
}