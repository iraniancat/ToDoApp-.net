using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entities;
using TodoApp.Infrastructure.Persistence;
using TodoApp.Infrastructure.Services;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly JwtTokenGenerator _tokenGenerator;

    public AuthController(ApplicationDbContext context, IConfiguration config)
    {
        _context = context;
        _tokenGenerator = new JwtTokenGenerator(config["Jwt:Key"]!);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User user)
    {
        if (_context.Users.Any(u => u.Username == user.Username))
            return BadRequest("Username already exists.");

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok("User registered.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] User login)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == login.Username && u.Password == login.Password);

        if (user == null)
            return Unauthorized();

        var token = _tokenGenerator.GenerateToken(user);
        return Ok(new { token });
    }
}
