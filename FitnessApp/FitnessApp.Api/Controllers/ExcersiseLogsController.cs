using FitnessApp.Application;
using FitnessApp.Application.Commands;
using FitnessApp.Application.Commands.LogExcersise;
using FitnessApp.Application.Queries.LogExcersise;
using FitnessApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogExercisesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LogExercisesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("workouts/{workoutId}")]
        public async Task<ActionResult<IEnumerable<LogExcersiseDto>>> GetAllLogExercisesByWorkoutId(Guid workoutId)
        {
            var query = new GetAllLogExercisesByWorkoutIdQuery { WorkoutId = workoutId };
            var logExercises = await _mediator.Send(query);
            return Ok(logExercises);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LogExcersiseDto>> GetLogExerciseById(Guid id)
        {
            var query = new GetLogExerciseByIdQuery { LogId = id };
            var logExercise = await _mediator.Send(query);
            if (logExercise is null)
            {
                return NotFound();
            }
            return Ok(logExercise);
        }

        [HttpPost]
        public async Task<ActionResult<LogExcersiseDto>> LogExercise([FromForm]LogExcersiseDto logExercise, Guid workoutId)
        {
            var command = new LogExerciseCommand { LogExersiseDto = logExercise, WorkoutId=workoutId };
            var createdLogExercise = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetLogExerciseById), new { id = createdLogExercise.LogId }, createdLogExercise);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateLogExercise([FromForm]LogExcersise logExercise)
        {
            var command = new UpdateLogExerciseCommand { LogExercise = logExercise };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogExercise(Guid id)
        {
            var command = new DeleteLogExerciseCommand { LogId = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}