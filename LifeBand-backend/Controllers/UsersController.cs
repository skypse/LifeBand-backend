using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LifeBand_backend.Data;
using LifeBand_backend.Dtos;
using LifeBand_backend.Models;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    // readonly garante que o campo só pode ser atribuído durante inicialização
    // ou no construtor da clase
    private readonly LifeBandDbContext _context;

    public UsersController(LifeBandDbContext context)
    {
        _context = context;
    }

    // POST api/users
    // Requisição para Adicionar um novo usuário:
    [HttpPost]
    public async Task<IActionResult> CreateUser(UserCreateDto userCreateDto)
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

    // GET api/users
    // Requisição para puxar todos usuários:
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _context.Users
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
                Endereco = u.Endereco,
                IsActive = u.IsActive
            })
            .ToListAsync();

        return Ok(users);
    }

    // GET api/users/{id}
    // Requisição para dar um GET em um usuário via ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        var userDto = new UserDto
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
        };

        return Ok(userDto);
    }

    // GET api/users/ativo
    // Requisição paara puxar usuários ativos
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

    // GET api/users/inativo
    // Requisição paara puxar usuários inátivos
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

    // PUT api/users/{id}
    // Requisição de UPDATE usuário via ID
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, UserCreateDto userCreateDto)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        // Atualiza os dados do usuário com base no DTO recebido
        user.Nome = userCreateDto.Nome;
        user.Data_Nascimento = userCreateDto.Data_Nascimento;
        user.Telefone = userCreateDto.Telefone;
        user.Email = userCreateDto.Email;
        user.Genero = userCreateDto.Genero;
        user.Tipo_Sanguineo = userCreateDto.Tipo_Sanguineo;
        user.RG = userCreateDto.RG;
        user.Cpf = userCreateDto.Cpf;
        user.Historico_Medico = userCreateDto.Historico_Medico;
        user.Endereco = userCreateDto.Endereco;

        try
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return BadRequest();
            throw;
        }

        return NoContent();
    }

    // DELETE api/users/{id}
    // Requisição de Delete lógico de um usuário via ID
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        // Definindo usuário como inátivo
        user.IsActive = false;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            throw;
        }

        return NoContent();
    }
}
