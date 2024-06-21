using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LifeBand_backend.Data;
using LifeBand_backend.Models;
using LifeBand_backend.Dtos.Pulseira;

[ApiController]
[Route("api/pulseiras")]
public class PulseiraController : ControllerBase
{
    private readonly LifeBandDbContext _context;

    public PulseiraController(LifeBandDbContext context)
    {
        _context = context;
    }

    // POST api/pulseiras
    // Requisição para adicionar a pulseira a um usuário
    [HttpPost]
    public async Task<IActionResult> CreatePulseira(PulseiraCreateDto pulseiraCreateDto)
    {
        // Verificar se o usuário existe
        var user = await _context.Users.FindAsync(pulseiraCreateDto.UserId);

        if (user == null)
        {
            return NotFound(new { message = "Usuário não foi encontrado!" });
        }

        var pulseira = new Pulseira
        {
            Id = Guid.NewGuid(),
            ContatoEmergenciaNome = pulseiraCreateDto.ContatoEmergenciaNome,
            ContatoEmergenciaTelefone = pulseiraCreateDto.ContatoEmergenciaTelefone,
            DoencaCronica = pulseiraCreateDto.DoencaCronica,
            GrauDeRisco = pulseiraCreateDto.GrauDeRisco,
            UserId = pulseiraCreateDto.UserId,
            IsActive = true
        };

        _context.Pulseiras.Add(pulseira);
        await _context.SaveChangesAsync();

        var pulseiraDto = new PulseiraDto
        {
            Id = pulseira.Id,
            ContatoEmergenciaNome = pulseira.ContatoEmergenciaNome,
            ContatoEmergenciaTelefone = pulseira.ContatoEmergenciaTelefone,
            DoencaCronica = pulseira.DoencaCronica,
            GrauDeRisco = pulseira.GrauDeRisco,
            IsActive = pulseira.IsActive,
            UserId = pulseira.UserId
        };

        return Ok(pulseiraDto);
    }

    // GET api/pulseiras
    // Requisição para puxar todas pulseiras
    [HttpGet]
    public async Task<IActionResult> GetAllPulseiras()
    {
        var pulseiras = await _context.Pulseiras
            .Select(p => new PulseiraDto
            {
                Id = p.Id,
                ContatoEmergenciaNome = p.ContatoEmergenciaNome,
                ContatoEmergenciaTelefone = p.ContatoEmergenciaTelefone,
                DoencaCronica = p.DoencaCronica,
                GrauDeRisco = p.GrauDeRisco,
                IsActive = p.IsActive,
                UserId = p.UserId
            })
            .ToListAsync();

        return Ok(pulseiras);
    }

    // GET api/pulseiras/{id}
    // Requisição para puxar a pulseira via ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPulseiraById(Guid id)
    {
        var pulseira = await _context.Pulseiras.FindAsync(id);

        if (pulseira == null)
        {
            return NotFound();
        }

        var pulseiraDto = new PulseiraDto
        {
            Id = pulseira.Id,
            ContatoEmergenciaNome = pulseira.ContatoEmergenciaNome,
            ContatoEmergenciaTelefone = pulseira.ContatoEmergenciaTelefone,
            DoencaCronica = pulseira.DoencaCronica,
            GrauDeRisco = pulseira.GrauDeRisco,
            IsActive = pulseira.IsActive,
            UserId = pulseira.UserId
        };

        return Ok(pulseiraDto);
    }

    // PUT api/pulseiras/{id}
    // Requisição para atualizar dados da pulseira
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePulseira(Guid id, PulseiraCreateDto pulseiraCreateDto)
    {
        var pulseira = await _context.Pulseiras.FindAsync(id);

        if (pulseira == null)
        {
            return NotFound();
        }

        pulseira.ContatoEmergenciaNome = pulseiraCreateDto.ContatoEmergenciaNome;
        pulseira.ContatoEmergenciaTelefone = pulseiraCreateDto.ContatoEmergenciaTelefone;
        pulseira.DoencaCronica = pulseiraCreateDto.DoencaCronica;
        pulseira.GrauDeRisco = pulseiraCreateDto.GrauDeRisco;
        pulseira.UserId = pulseiraCreateDto.UserId;

        try
        {
            _context.Entry(pulseira).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PulseiraExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE api/pulseiras/{id}
    // Requisição de desativar a pulseira
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePulseira(Guid id)
    {
        var pulseira = await _context.Pulseiras.FindAsync(id);

        if (pulseira == null)
        {
            return NotFound();
        }

        pulseira.IsActive = false;

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

    private bool PulseiraExists(Guid id)
    {
        return _context.Pulseiras.Any(e => e.Id == id);
    }
}
