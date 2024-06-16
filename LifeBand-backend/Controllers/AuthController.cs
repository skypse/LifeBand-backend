using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using LifeBand_backend.Data;
using LifeBand_backend.Dtos;
using LifeBand_backend.Models;
using LifeBand_backend.Services;


[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly LifeBandDbContext _context;
    private readonly IJwtAuthenticationManager _jwtAuthenticationManager;

    public AuthController(LifeBandDbContext context, IJwtAuthenticationManager jwtAuthenticationManager)
    {
        _context = context;
        _jwtAuthenticationManager = jwtAuthenticationManager;
    }

    // api/auth/login POST
    [HttpPost("login")]
    public async Task<IActionResult> Login(UserCredencialDto userCredencialDto)
    {
        var user = await _context.Users
            .SingleOrDefaultAsync(u => u.Email == userCredencialDto.Email && u.Password == userCredencialDto.Password && u.Cpf == userCredencialDto.Cpf);

        if (user != null)
        {
            var token = _jwtAuthenticationManager.GenerateToken(user.Email, user.Cpf);
            return Ok(new AuthResponseDto { Mensagem = "Login Efetuado com Sucesso!", Token = token });
        }
        return Unauthorized(new AuthResponseDto { Mensagem = "Credenciais Inválidas!"});
    }
}