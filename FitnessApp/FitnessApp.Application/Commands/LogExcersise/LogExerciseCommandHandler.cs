using FitnessApp.Contracts.Interfaces.Repositories;
using MediatR;

namespace FitnessApp.Application.Commands.LogExcersise
{
    public class LogExerciseCommandHandler:IRequestHandler<LogExerciseCommand,Domain.Entities.LogExcersise>
	{
        private readonly IExcersiseLogRepository _excersiseLogRepository;
        public LogExerciseCommandHandler(IExcersiseLogRepository excersiseLogRepository)
        {
            _excersiseLogRepository = excersiseLogRepository;
        }

        public async Task<Domain.Entities.LogExcersise> Handle(LogExerciseCommand request, CancellationToken cancellationToken)
        {
            var logExcersiseEntity = LogExcersiseMapper.ToEntity(request.LogExersiseDto, request.WorkoutId);
            return await _excersiseLogRepository.LogExcersiseAsync(logExcersiseEntity);
        }
    }
}