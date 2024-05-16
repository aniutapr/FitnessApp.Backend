using FitnessApp.Domain.Entities;

namespace FitnessApp.Application
{
    public static class WorkoutAdapter
    {
        public static WorkoutDto ToDto(this Workout workout)
        {
            var logExcersiseDtos = workout.Exercises.Select(e => LogExcersiseAdapter.ToDto(e)).ToList();

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
            var logExcersises = workoutDto.Excersises.Select(e => LogExcersiseAdapter.ToEntity(e, userId)).ToList();

            return new Workout
            {
                UserId = userId,
                DateTime = workoutDto.DateTime,
                DurationInMin = workoutDto.DurationInMin,
                Stars = workoutDto.Stars,
                HowHard = workoutDto.HowHard,
                Exercises = logExcersises
            };
        }
    }
}
