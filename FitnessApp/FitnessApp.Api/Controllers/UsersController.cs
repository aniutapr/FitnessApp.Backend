using FitnessApp.Api.Dto;
using FitnessApp.Contracts.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Api.Controllers;

[Route("api/[controller]")]
public class UsersController : Controller
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromForm] UserRegisterDto userDto)
    {
        await _userService.Register(userDto.Username, userDto.Email, userDto.Password);
        return Ok();
    }
    [HttpPost("login")]
    public async Task<ActionResult<string>> Login([FromForm] UserLoginDto userLoginDto)
    {
        var token = await _userService.Login(userLoginDto.Email, userLoginDto.Password);
        return Ok(token);
    }

}