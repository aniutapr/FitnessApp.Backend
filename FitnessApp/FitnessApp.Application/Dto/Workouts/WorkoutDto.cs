using System;
using FitnessApp.Domain.Entities;

namespace FitnessApp.Application;

public class WorkoutDto
{
    public ICollection<LogExcersiseDto> Excersises { get; set; }
    public DateTime DateTime { get; set; }
    public int DurationInMin { get; set; }
    public int Stars { get; set; }
    public int HowHard { get; set; }
}
