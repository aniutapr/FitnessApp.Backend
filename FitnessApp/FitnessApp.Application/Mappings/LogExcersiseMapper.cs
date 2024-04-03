using System;
using FitnessApp.Domain.Entities;

namespace FitnessApp.Application
{
    public static class LogExcersiseMapper
    {
        public static LogExcersise ToEntity(LogExcersiseDto logExcersiseDto, Guid workoutId)
        {
            return new LogExcersise
            {
                LogId = Guid.NewGuid(),
                ExcersiseId = logExcersiseDto.ExcersiseId,
                WorkoutId = workoutId,
                DurationInMin = logExcersiseDto.DurationInMin,
                Weight = logExcersiseDto.Weight,
                Repeats = logExcersiseDto.Repeats,
                Sets = logExcersiseDto.Sets
            };
        }

        public static LogExcersiseDto ToDto(LogExcersise logExcersise)
        {
            return new LogExcersiseDto
            {
                ExcersiseId = logExcersise.ExcersiseId,
                DurationInMin = logExcersise.DurationInMin,
                Weight = logExcersise.Weight,
                Repeats = logExcersise.Repeats,
                Sets = logExcersise.Sets
            };
        }
    }
}