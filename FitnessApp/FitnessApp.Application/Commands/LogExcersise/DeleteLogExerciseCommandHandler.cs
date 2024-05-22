using FitnessApp.Contracts.Interfaces.Repositories;
using MediatR;

namespace FitnessApp.Application.Commands.LogExcersise
{
    public class DeleteLogExerciseCommandHandler:IRequestHandler<DeleteLogExerciseCommand, Unit>
	{
        private readonly IExcersiseLogRepository _excersiseLogRepository;
		public DeleteLogExerciseCommandHandler(IExcersiseLogRepository excersiseLogRepository)
		{
            _excersiseLogRepository = excersiseLogRepository;
		}

        public async Task<Unit> Handle(DeleteLogExerciseCommand request, CancellationToken cancellationToken)
        {
            await _excersiseLogRepository.DeleteLogAsync(request.LogId);
            return Unit.Value;
        }
    }
}