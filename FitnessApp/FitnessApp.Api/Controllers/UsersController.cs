using FitnessApp.Api.Dto;
using FitnessApp.Contracts.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Api.Controllers;

[Route("api/[controller]")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UsersController(IUserService userService, IRoleService roleService, IHttpContextAccessor httpContextAccessor)
    {
        _userService = userService;
        _roleService = roleService;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromForm] UserRegisterDto userDto)
    {
        var role = await _roleService.GetRoleByName("User");

        if (role == null)
        {
            return BadRequest("Role not found");
        }
        await _userService.Register(userDto.Username, userDto.Email, userDto.Password, role);
        return Ok();
    }

    [HttpPost("register/admin")]
    public async Task<IActionResult> RegisterAnAdmin([FromForm] UserRegisterDto userDto)
    {
        var role = await _roleService.GetRoleByName("Admin");

        if (role == null)
        {
            return BadRequest("Role not found");
        }
        await _userService.Register(userDto.Username, userDto.Email, userDto.Password, role);
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