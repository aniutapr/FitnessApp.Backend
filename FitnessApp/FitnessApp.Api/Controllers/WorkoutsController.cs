﻿using FitnessApp.Application;
using FitnessApp.Application.Commands.Workouts;
using FitnessApp.Application.Queries.Workouts;
using FitnessApp.Contracts.Interfaces.Repositories;
using FitnessApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkoutsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IWorkoutRepository _workoutRepository;

    public WorkoutsController(IMediator mediator, IWorkoutRepository workoutRepository)
    {
        _mediator = mediator;
        _workoutRepository = workoutRepository;
    }
    [HttpPost("{id}/clone")]
    public async Task<ActionResult<WorkoutDto>> CloneWorkout(Guid id)
    {
        var command = new CloneWorkoutCommand { WorkoutId = id };
        var clonedWorkout = await _mediator.Send(command);

        if (clonedWorkout == null)
        {
            return NotFound(); 
        }

        return clonedWorkout;    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorkoutDto>>> GetAllWorkoutsByUserId()
    {
        var id = new Guid();
        var query = new GetAllWorkoutsByUserIdQuery { UserId=id};
        var workouts = _mediator.Send(query);
        return Ok(workouts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WorkoutDto>> GetWorkoutById(Guid id)
    {
        var query = new GetWorkoutByIdQuery { WorkoutId = id };
        var workout = _mediator.Send(query);
        if(workout is null)
        {
            return NotFound();
        }
        return Ok(workout);
    }

    [HttpPost]
    public async Task<ActionResult<WorkoutDto>> CreateWorkout([FromForm]WorkoutDto workout)
    {
        var command = new CreateWorkoutCommand { Workout = workout };
        var createdWorkout=await _mediator.Send(command);
        return CreatedAtAction(nameof(GetWorkoutById), new { id = createdWorkout.WorkoutId }, createdWorkout);
    }
    [HttpPut()]
    public async Task<IActionResult> UpdateWorkout([FromForm]Workout workout)
    {
        var command = new UpdateWorkoutCommand { Workout = workout };
        await _mediator.Send(command);
        return NoContent();
        
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkout(Guid id)
    {
        var command = new DeleteWorkoutCommand { WorkoutId = id };
        await _mediator.Send(command);
        return NoContent();
    }
}