using System;
using FitnessApp.Contracts.Interfaces.Repositories;
using MediatR;

namespace FitnessApp.Application.Commands.Excersises
{
	public class DeleteExcersiseCommandHandler:IRequestHandler<DeleteExcersiseCommand, Unit>
	{
        private readonly IExcersiseRepository _excersiseRepository;
		public DeleteExcersiseCommandHandler(IExcersiseRepository excersiseRepository)
		{
            _excersiseRepository = excersiseRepository;
		}

        public async Task<Unit> Handle(DeleteExcersiseCommand request, CancellationToken cancellationToken)
        {
            await _excersiseRepository.DeleteExcersiseAsync(request.Id);
            return Unit.Value;
        }
    }
}