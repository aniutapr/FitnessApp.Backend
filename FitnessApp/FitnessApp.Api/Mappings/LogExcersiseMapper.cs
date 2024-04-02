using FitnessApp.Api.Dto;
using FitnessApp.Domain.Entities;
using System;

namespace FitnessApp.Api.Mappings;

public static class LogExcersiseMapper
{
    public static LogExcersise MapToLogExcersise(LogExcersiseDto logExcersiseDto)
    {
        return new LogExcersise
        {
            LogId = Guid.NewGuid(),
            ExcersiseId = logExcersiseDto.ExcersiseId,
            WorkoutId = logExcersiseDto.WorkoutId,
            DurationInMin = logExcersiseDto.DurationInMin,
            Weight = logExcersiseDto.Weight,
            Repeats = logExcersiseDto.Repeats,
            Sets = logExcersiseDto.Sets
        };
    }
}