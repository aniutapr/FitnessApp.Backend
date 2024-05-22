using FitnessApp.Application;
using FitnessApp.Contracts.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UsersController(IUserService userService, IHttpContextAccessor httpContextAccessor)
    {
        _userService = userService;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost("/register")]
    public async Task<IActionResult> Register([FromForm] UserRegisterDto userDto)
    {
        await _userService.Register(userDto.Username, userDto.Email, userDto.Password);
        return Ok();
    }

    [HttpPost("/login")]
    public async Task<ActionResult<string>> Login([FromForm] UserLoginDto userLoginDto)
    {
        var token = await _userService.Login(userLoginDto.Email, userLoginDto.Password);
        _httpContextAccessor.HttpContext.Response.Cookies.Append("JwtToken", token);

        return Ok(token);
    }
}