
using System;
namespace FitnessApp.Domain.Entities;

public class WorkoutGoal
{
	public Guid Id { get; set; }
	public int Duration { get; set; }
    public DateOnly Date { get; set; }
    public bool IsDone { get; set; }
}