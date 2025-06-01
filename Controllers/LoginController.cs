using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PizzaBE.Dtos;
using PizzaBE.Models;
using System.Threading.Tasks;

[ApiController]
[Route("api/[action]")]
public class LoginController : ControllerBase
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public LoginController(SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user == null)
            return Unauthorized("Invalid email or password");

        var result = await _signInManager.PasswordSignInAsync(user, dto.Password, isPersistent: true, lockoutOnFailure: false);
        if (!result.Succeeded)
            return Unauthorized("Invalid email or password");
        Response.Redirect("http://localhost:5173/");
        return Ok("Logged in successfully");
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetMyInfo()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
            return Unauthorized();

        return Ok(new UserDto
        {
            Email = user.Email,
            Role = user.Role
        });
    }
    [HttpPost()]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        Response.Redirect("http://localhost:5173/login");
        return Ok("Logged out successfully");
    }
    [HttpPost()]
   
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        var existing = await _userManager.FindByEmailAsync(dto.Email);
        if (existing != null)
            return BadRequest("Email already registered");

        var user = new User
        {
            UserName = dto.Email,
            Email = dto.Email,
            Role = PizzaBE.Enums.ERoles.CUSTOMER 
        };

        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
            return BadRequest(result.Errors);

        await _signInManager.SignInAsync(user, isPersistent: true);
        Response.Redirect("http://localhost:5173/");
        return Ok("Registration successful and user logged in");
    }
}
