using FitnessApp.Application;
using FitnessApp.Application.Commands;
using FitnessApp.Application.Commands.Excersises;
using FitnessApp.Application.Excersises.Queries;
using FitnessApp.Application.Queries.Excersises;
using FitnessApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ExcersisesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExcersisesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExcersiseDto>>> GetAllExcersises()
    {
        var excersises = await _mediator.Send(new GetAllExcersisesQuery());
        return Ok(excersises);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ExcersiseDto>> GetExcersiseById(Guid id)
    {
        var excersise = await _mediator.Send(new GetExcersiseByIdQuery { Id = id });

        if (excersise is null)
            return NotFound();

        return Ok(excersise);
    }

    [HttpPost]
    public async Task<ActionResult<ExcersiseDto>> CreateExcersise([FromForm] ExcersiseDto excersiseDto)
    {
        var command = new CreateExcersiseCommand { ExcersiseDto = excersiseDto };
        var createdExcersise = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetExcersiseById), new { id = createdExcersise.Id }, createdExcersise);
    }

    [HttpPut()]
    public async Task<IActionResult> UpdateExcersise([FromForm] Excersise excersise)
    {
        var command = new UpdateExcersiseCommand
        {
            Excersise = excersise
        };

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExcersise(Guid id)
    {
        var command = new DeleteExcersiseCommand { Id = id };
        await _mediator.Send(command);

        return NoContent();
    }
}