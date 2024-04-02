
using System;
namespace FitnessApp.Domain.Entities
{
	public class LogExcersise
	{
		public Guid LogId { get; set; }
		public Guid ExcersiseId { get; set; }
		public Guid WorkoutId { get; set; }
		public int DurationInMin { get; set; }
		public int Weight { get; set; }
		public int Repeats { get; set; }
        public int Sets { get; set; }
    }
}