using FitnessApp.Contracts.Interfaces.Repositories;
using FitnessApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkoutsController : ControllerBase
{
    private readonly IWorkoutRepository _repository;

    public WorkoutsController(IWorkoutRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Workout>>> GetAllWorkouts()
    {
        var workouts = await _repository.GetAllWorkoutsAsync();
        return Ok(workouts); 
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Workout>> GetWorkoutById(Guid id)
    {
        var workout = await _repository.GetWorkoutByIdAsync(id);
        if (workout == null)
        {
            return NotFound(); 
        }
        return Ok(workout); 
    }

    [HttpPost]
    public async Task<ActionResult<Workout>> CreateWorkout(Workout workout)
    {
        var createdWorkout = await _repository.AddWorkoutAsync(workout);
        return CreatedAtAction(nameof(GetWorkoutById), new { id = createdWorkout.WorkoutId }, createdWorkout); // HTTP 201 Created
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWorkout(Guid id, Workout workout)
    {
        if (id != workout.WorkoutId)
        {
            return BadRequest(); 
        }

        await _repository.UpdateWorkoutAsync(workout);
        return NoContent(); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkout(Guid id)
    {
        await _repository.DeleteWorkoutAsync(id);
        return NoContent(); 
    }
}