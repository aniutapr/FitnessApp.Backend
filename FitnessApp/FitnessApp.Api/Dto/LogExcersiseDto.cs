namespace FitnessApp.Api.Dto;

public class LogExcersiseDto
{
    public Guid ExcersiseId { get; set; }
    public Guid WorkoutId { get; set; }
    public int DurationInMin { get; set; }
    public int Weight { get; set; }
    public int Repeats { get; set; }
    public int Sets { get; set; }
}