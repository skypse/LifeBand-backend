using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LifeBand_backend.Data;
using LifeBand_backend.Dtos.Funcionario;
using LifeBand_backend.Models;
using LifeBand_backend.Services;
using System.Threading.Tasks;
using LifeBand_backend.Dtos;

namespace LifeBand_backend.Controllers
{
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

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(FuncionarioCredencialDto funcionarioCredencialDto)
        {
            // Verifica se as credenciais são de um funcionário
            var funcionario = await _context.Funcionarios
                .SingleOrDefaultAsync(f => f.Email == funcionarioCredencialDto.Email &&
                                           f.Senha == funcionarioCredencialDto.Password &&
                                           f.Cpf == funcionarioCredencialDto.Cpf);

            if (funcionario != null)
            {
                // Gera um token JWT usando o gerenciador de autenticação JWT
                var token = _jwtAuthenticationManager.GenerateToken(funcionario.Email, funcionario.Cpf, true);

                return Ok(new AuthResponseDto { Mensagem = "Login do funcionário efetuado com sucesso!", Token = token });
            }

            // Verifica se as credenciais são de um paciente
            var paciente = await _context.Users
                .SingleOrDefaultAsync(u => u.Email == funcionarioCredencialDto.Email &&
                                           u.Password == funcionarioCredencialDto.Password &&
                                           u.Cpf == funcionarioCredencialDto.Cpf);

            if (paciente != null)
            {
                // Gera um token JWT usando o gerenciador de autenticação JWT
                var token = _jwtAuthenticationManager.GenerateToken(paciente.Email, paciente.Cpf, false);

                return Ok(new AuthResponseDto { Mensagem = "Login do paciente efetuado com sucesso!", Token = token });
            }

            // Retorna 'não autorizado' caso as credenciais sejam inválidas
            return Unauthorized(new AuthResponseDto { Mensagem = "Credenciais inválidas!" });
        }
    }
}
