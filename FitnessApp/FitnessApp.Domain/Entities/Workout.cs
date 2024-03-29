namespace FitnessApp.Domain.Entities;

public class Workout
{
    public Guid WorkoutId { get; set; }
    public Guid UserId { get; set; }
    public ICollection<LogExcersise> Excersises { get; set; }
    public DateTime DateTime { get; set; }
    public int DurationInMin { get; set; }
    public int Stars { get; set; }
    public int HowHard { get; set; }
}