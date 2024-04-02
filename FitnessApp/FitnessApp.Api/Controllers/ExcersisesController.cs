using FitnessApp.Contracts.Interfaces.Repositories;
using FitnessApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Api.Controllers;

[Route("api/[controller]")]
public class ExcersisesController : Controller
{
    private readonly IExcersiseRepository _excersiseRepository;
    public ExcersisesController(IExcersiseRepository excersiseRepository)
    {
        _excersiseRepository = excersiseRepository;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Excersise>>> GetAllExcersises()
    {
        var excersises = await _excersiseRepository.GetAllExcersisesAsync();
        return Ok(excersises);
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/values
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