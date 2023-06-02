using Application.Contacts.Requests.Tokens;
using Application.Contacts.Requests.Users;
using Application.Contacts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ITokenService _service;
    private readonly IUserService _userService;

    public AuthController(ITokenService service, IUserService userService)
    {
        _service = service;
        _userService = userService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] CreateTokenRequest request)
    {
        var token = _service.GenerateToken(request);

        return Ok(token);
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterUserRequest request)
    {
        _userService.Register(request);

        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteUser([FromRoute] Guid id)
    {
        _userService.DeleteUser(id);

        return Ok();
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetUserById([FromRoute] Guid id)
    {
        var result = _userService.GetUserById(id);

        return Ok(result);
    }

    [HttpGet]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetAllUsers()
    {
        var result = _userService.GetAllUsers();

        return Ok(result);
    }
}