using FitnessApp.Contracts.Interfaces.Repositories;
using FitnessApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FitnessApp.Api.Controllers;

[Route("api/[controller]")]
public class WorkoutsController : Controller
{
    private readonly IWorkoutRepository _repository;

    public WorkoutsController(IWorkoutRepository repository)
    {
        _repository = repository;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Workout>>> Get()
    {
        var workouts = await _repository.GetAllWorkoutsAsync();
        if (workouts == null || !workouts.Any())
        {
            return NotFound(); 
        }
        return Ok(workouts); 
    }

    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    [HttpPost]
    public void Post([FromBody]string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}