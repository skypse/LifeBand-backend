using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeBand_backend.Data;
using LifeBand_backend.Dtos;
using LifeBand_backend.Models;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly LifeBandDbContext _context;

    public UsersController(LifeBandDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserCreateDto userCreateDto)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Nome = userCreateDto.Nome,
            Data_Nascimento = userCreateDto.Data_Nascimento,
            Telefone = userCreateDto.Telefone,
            Email = userCreateDto.Email,
            Genero = userCreateDto.Genero,
            Tipo_Sanguineo = userCreateDto.Tipo_Sanguineo,
            RG = userCreateDto.RG,
            Cpf = userCreateDto.Cpf,
            Historico_Medico = userCreateDto.Historico_Medico,
            Password = userCreateDto.Password,
            Endereco = userCreateDto.Endereco,
            IsActive = true
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(new UserDto
        {
            Id = user.Id,
            Nome = user.Nome,
            Data_Nascimento = user.Data_Nascimento,
            Telefone = user.Telefone,
            Email = user.Email,
            Genero = user.Genero,
            Tipo_Sanguineo = user.Tipo_Sanguineo,
            RG = user.RG,
            Cpf = user.Cpf,
            Historico_Medico = user.Historico_Medico,
            Endereco = user.Endereco
        });
    }

    [HttpGet("ativo")]
    public async Task<IActionResult> GetActiveUsers()
    {
        var users = await _context.Users
            .Where(u => u.IsActive)
            .Select(u => new UserDto
            {
                Id = u.Id,
                Nome = u.Nome,
                Data_Nascimento = u.Data_Nascimento,
                Telefone = u.Telefone,
                Email = u.Email,
                Genero = u.Genero,
                Tipo_Sanguineo = u.Tipo_Sanguineo,
                RG = u.RG,
                Cpf = u.Cpf,
                Historico_Medico = u.Historico_Medico,
                Endereco = u.Endereco
            })
            .ToListAsync();

        return Ok(users);
    }

    [HttpGet("inativo")]
    public async Task<IActionResult> GetInactiveUsers()
    {
        var users = await _context.Users
            .Where(u => !u.IsActive)
            .Select(u => new UserDto
            {
                Id = u.Id,
                Nome = u.Nome,
                Data_Nascimento = u.Data_Nascimento,
                Telefone = u.Telefone,
                Email = u.Email,
                Genero = u.Genero,
                Tipo_Sanguineo = u.Tipo_Sanguineo,
                RG = u.RG,
                Cpf = u.Cpf,
                Historico_Medico = u.Historico_Medico,
                Endereco = u.Endereco
            })
            .ToListAsync();

        return Ok(users);
    }
}
