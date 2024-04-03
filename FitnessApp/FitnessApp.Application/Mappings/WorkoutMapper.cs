using FitnessApp.Domain.Entities;

namespace FitnessApp.Application
{
    public static class WorkoutMapper
    {
        public static WorkoutDto ToDto(this Workout workout)
        {
            var logExcersiseDtos = workout.Excersises.Select(e => LogExcersiseMapper.ToDto(e)).ToList();

            return new WorkoutDto
            {
                Excersises = logExcersiseDtos,
                DateTime = workout.DateTime,
                DurationInMin = workout.DurationInMin,
                Stars = workout.Stars,
                HowHard = workout.HowHard
            };
        }

        public static Workout ToEntity(this WorkoutDto workoutDto, Guid userId)
        {
            var logExcersises = workoutDto.Excersises.Select(e => LogExcersiseMapper.ToEntity(e, userId)).ToList();

            return new Workout
            {
                UserId = userId,
                DateTime = workoutDto.DateTime,
                DurationInMin = workoutDto.DurationInMin,
                Stars = workoutDto.Stars,
                HowHard = workoutDto.HowHard,
                Excersises = logExcersises
            };
        }
    }
}
