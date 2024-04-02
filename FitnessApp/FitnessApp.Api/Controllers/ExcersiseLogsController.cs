using FitnessApp.Api.Dto;
using FitnessApp.Api.Mappings;
using FitnessApp.Contracts.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExcersiseLogsController : ControllerBase
{
    private readonly IExcersiseLogRepository _excersiseLogsRepository;

    public ExcersiseLogsController(IExcersiseLogRepository excersiseLogRepository)
    {
        _excersiseLogsRepository = excersiseLogRepository;
    }

    [HttpPost]
    public async Task<ActionResult> LogExcersise(LogExcersiseDto logExcersiseDto)
    {
        var logExcersise = LogExcersiseMapper.MapToLogExcersise(logExcersiseDto);
        await _excersiseLogsRepository.LogExcersiseAsync(logExcersise);
        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteLog(Guid id)
    {
        await _excersiseLogsRepository.DeleteLogAsync(id);
        return Ok();
    }
}
