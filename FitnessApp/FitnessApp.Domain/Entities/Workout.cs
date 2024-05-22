
using System;
using System.Collections.Generic;

namespace FitnessApp.Domain.Entities
{
    public class Workout
    {
        public Guid WorkoutId { get; set; }
        public Guid UserId { get; set; }
        public ICollection<LogExcersise> Exercises { get; set; }
        public DateTime DateTime { get; set; }
        public int DurationInMin { get; set; }
        public int Stars { get; set; }
        public int HowHard { get; set; }

        // Manually implement cloning method
        public Workout Clone()
        {
            // Create a new workout object
            var newWorkout = new Workout
            {
                WorkoutId = Guid.NewGuid(), // Generate new GUID for the cloned workout
                UserId = this.UserId,
                DateTime = this.DateTime,
                DurationInMin = this.DurationInMin,
                Stars = this.Stars,
                HowHard = this.HowHard
            };

            // Copy exercises
            if (Exercises != null)
            {
                newWorkout.Exercises = new List<LogExcersise>();
                foreach (var exercise in Exercises)
                {
                    newWorkout.Exercises.Add(exercise.Clone());
                }
            }

            return newWorkout;
        }

    }
}
