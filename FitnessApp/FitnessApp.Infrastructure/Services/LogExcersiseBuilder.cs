using System;
using FitnessApp.Domain.Entities;

namespace FitnessApp.Infrastructure
{
    public class LogExerciseBuilder
    {
        private Guid _logId;
        private Guid _exerciseId;
        private Guid _workoutId;
        private int _durationInMin;
        private int _weight;
        private int _repeats;
        private int _sets;

        public LogExerciseBuilder()
        {
            _logId = Guid.NewGuid(); 
        }

        public LogExerciseBuilder WithExerciseId(Guid exerciseId)
        {
            _exerciseId = exerciseId;
            return this;
        }

        public LogExerciseBuilder WithWorkoutId(Guid workoutId)
        {
            _workoutId = workoutId;
            return this;
        }

        public LogExerciseBuilder WithDuration(int durationInMin)
        {
            _durationInMin = durationInMin;
            return this;
        }

        public LogExerciseBuilder WithWeight(int weight)
        {
            _weight = weight;
            return this;
        }

        public LogExerciseBuilder WithRepeats(int repeats)
        {
            _repeats = repeats;
            return this;
        }

        public LogExerciseBuilder WithSets(int sets)
        {
            _sets = sets;
            return this;
        }

        public LogExcersise Build()
        {
            return new LogExcersise
            {
                LogId = _logId,
                ExcersiseId = _exerciseId,
                WorkoutId = _workoutId,
                DurationInMin = _durationInMin,
                Weight = _weight,
                Repeats = _repeats,
                Sets = _sets
            };
        }
    }
}
