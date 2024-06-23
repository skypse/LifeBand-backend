using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LifeBand_backend.Data;
using LifeBand_backend.Models;
using LifeBand_backend.Dtos.Agendamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeBand_backend.Controllers
{
    [Route("api/agendamento")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly LifeBandDbContext _context;

        public AgendamentoController(LifeBandDbContext context)
        {
            _context = context;
        }

        // GET: api/agendamento
        // Retorna todos os agendamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgendamentoDto>>> GetAgendamentos()
        {
            var agendamentos = await _context.Agendamentos
                .Include(a => a.FuncionarioResponsavel)
                .Select(a => new AgendamentoDto
                {
                    Id = a.Id,
                    FuncionarioId = a.FuncionarioId,
                    FuncionarioNome = a.FuncionarioResponsavel.Nome,
                    UserId = a.UserId,
                    TipoExame = a.TipoExame,
                    DataExame = a.DataExame,
                    HorarioExame = a.HorarioExame,
                    Diagnostico = a.Diagnostico,
                    Observacoes = a.Observacoes,
                    Status = a.Status
                })
                .ToListAsync();

            return Ok(agendamentos);
        }

        // GET: api/agendamento/{id}
        // Retorna um agendamento pelo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<AgendamentoDto>> GetAgendamentoById(Guid id)
        {
            var agendamento = await _context.Agendamentos
                .Include(a => a.FuncionarioResponsavel)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (agendamento == null)
            {
                return NotFound();
            }

            var agendamentoDto = new AgendamentoDto
            {
                Id = agendamento.Id,
                FuncionarioId = agendamento.FuncionarioId,
                FuncionarioNome = agendamento.FuncionarioResponsavel.Nome,
                UserId = agendamento.UserId,
                TipoExame = agendamento.TipoExame,
                DataExame = agendamento.DataExame,
                HorarioExame = agendamento.HorarioExame,
                Diagnostico = agendamento.Diagnostico,
                Observacoes = agendamento.Observacoes,
                Status = agendamento.Status
            };

            return Ok(agendamentoDto);
        }

        // POST: api/agendamento
        // Cria um novo agendamento
        [HttpPost]
        public async Task<ActionResult<AgendamentoDto>> CreateAgendamento(AgendamentoCreateDto agendamentoDto)
        {
            var funcionario = await _context.Funcionarios
                .FirstOrDefaultAsync(f => f.Nome == agendamentoDto.FuncionarioNome);

            if (funcionario == null)
            {
                return BadRequest("Funcionário não encontrado");
            }

            var novoAgendamento = new Agendamento
            {
                FuncionarioId = funcionario.Id,
                UserId = agendamentoDto.UserId,
                TipoExame = agendamentoDto.TipoExame,
                DataExame = agendamentoDto.DataExame,
                HorarioExame = agendamentoDto.HorarioExame,
                Diagnostico = agendamentoDto.Diagnostico,
                Observacoes = agendamentoDto.Observacoes,
                Status = "ATIVO"
            };

            _context.Agendamentos.Add(novoAgendamento);
            await _context.SaveChangesAsync();

            var agendamentoResponse = new AgendamentoDto
            {
                Id = novoAgendamento.Id,
                FuncionarioId = novoAgendamento.FuncionarioId,
                FuncionarioNome = funcionario.Nome,
                UserId = novoAgendamento.UserId,
                TipoExame = novoAgendamento.TipoExame,
                DataExame = novoAgendamento.DataExame,
                HorarioExame = novoAgendamento.HorarioExame,
                Diagnostico = novoAgendamento.Diagnostico,
                Observacoes = novoAgendamento.Observacoes,
                Status = novoAgendamento.Status
            };

            return CreatedAtAction(nameof(GetAgendamentoById), new { id = novoAgendamento.Id }, agendamentoResponse);
        }

        // PUT: api/agendamento/{id}
        // Atualiza um agendamento existente pelo ID
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAgendamento(Guid id, AgendamentoUpdateDto agendamentoDto)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);

            if (agendamento == null)
            {
                return NotFound();
            }

            // aplicando apenas oque foi enviado
            agendamento.TipoExame = agendamentoDto.TipoExame;
            agendamento.DataExame = agendamentoDto.DataExame;
            agendamento.HorarioExame = agendamentoDto.HorarioExame;
            agendamento.Diagnostico = agendamentoDto.Diagnostico;
            agendamento.Observacoes = agendamentoDto.Observacoes;
            agendamento.Status = agendamentoDto.Status;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendamentoExists(id))
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

        // DELETE: api/agendamento/{id}
        // Marca um agendamento como "CANCELADO"
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgendamento(Guid id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);

            if (agendamento == null)
            {
                return NotFound();
            }

            agendamento.Status = "CANCELADO";

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendamentoExists(id))
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

        // Verifica se um agendamento com o ID especificado existe
        private bool AgendamentoExists(Guid id)
        {
            return _context.Agendamentos.Any(e => e.Id == id);
        }
    }
}