using FitnessApp.Api.Dto;
using FitnessApp.Contracts.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Api.Controllers;

[Route("api/[controller]")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public UsersController(IUserService userService, IHttpContextAccessor httpContext)
    {
        _userService = userService;
        _httpContextAccessor = httpContext;
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
        _httpContextAccessor.HttpContext.Response.Cookies.Append("Jwt token(absolutely secret)", token);
        return Ok(token);
    }
}