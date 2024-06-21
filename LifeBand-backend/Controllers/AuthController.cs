using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using LifeBand_backend.Data;
using LifeBand_backend.Dtos;
using LifeBand_backend.Models;
using LifeBand_backend.Services;
using LifeBand_backend.Dtos.User;


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
        // busca um usuário que corresponda o email/senha e cpf fornecido
        var user = await _context.Users
            .SingleOrDefaultAsync(u => u.Email == userCredencialDto.Email &&
                                       u.Password == userCredencialDto.Password &&
                                       u.Cpf == userCredencialDto.Cpf);
        // verifica se o usuário foi encontrado
        if (user != null)
        {
            // gera um token JWT usando o gerenciador de autenticação JWT
            var token = _jwtAuthenticationManager.GenerateToken(user.Email, user.Cpf);
            // retorna resposta 'sucesso' com o token JWT
            return Ok(new AuthResponseDto { Mensagem = "Login Efetuado com Sucesso!", Token = token });
        }
        // retorna 'não autorizado' caso as credenciais sejam inválidas
        return Unauthorized(new AuthResponseDto { Mensagem = "Credenciais Inválidas!"});
    }
}