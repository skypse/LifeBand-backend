using LifeBand_backend.Data;
using LifeBand_backend.Dtos.Funcionario;
using LifeBand_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeBand_backend.Controllers
{
    [Route("api/funcionario")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly LifeBandDbContext _context;

        public FuncionarioController(LifeBandDbContext context)
        {
            _context = context;
        }

        // POST api/funcionario
        // Requisição para Adicionar um novo funcionario:
        [HttpPost]
        public async Task<IActionResult> CreateFuncionario(FuncionarioCreateDto funcionarioCreateDto)
        {
            var funcionario = new Funcionario
            {
                Id = Guid.NewGuid(),
                Nome = funcionarioCreateDto.Nome,
                Sexo = funcionarioCreateDto.Sexo,
                Nacionalidade = funcionarioCreateDto.Nacionalidade,
                Estado_Civil = funcionarioCreateDto.Estado_Civil,
                Email = funcionarioCreateDto.Email,
                Telefone = funcionarioCreateDto.Telefone,
                RG = funcionarioCreateDto.RG,
                Data_Nascimento = funcionarioCreateDto.Data_Nascimento,
                CEP = funcionarioCreateDto.CEP,
                RF = Guid.NewGuid(),
                Formacao = funcionarioCreateDto.Formacao,
                Cargo = funcionarioCreateDto.Cargo,
                Carga_Horaria = funcionarioCreateDto.Carga_Horaria,
                Expediente = funcionarioCreateDto.Expediente,
                Salario = funcionarioCreateDto.Salario,
                Senha = funcionarioCreateDto.Senha,
                Cpf = funcionarioCreateDto.Cpf
            };

            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();

            var funcionarioDto = new FuncionarioDto
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Sexo = funcionario.Sexo,
                Nacionalidade = funcionario.Nacionalidade,
                Estado_Civil = funcionario.Estado_Civil,
                Email = funcionario.Email,
                Telefone = funcionario.Telefone,
                RG = funcionario.RG,
                Data_Nascimento = funcionario.Data_Nascimento,
                CEP = funcionario.CEP,
                RF = funcionario.RF,
                Formacao = funcionario.Formacao,
                Cargo = funcionario.Cargo,
                Carga_Horaria = funcionario.Carga_Horaria,
                Expediente = funcionario.Expediente,
                Salario = funcionario.Salario,
                IsActive = funcionario.IsActive,
                Cpf = funcionario.Cpf,
                Senha = funcionario.Senha,
                Role = funcionario.Role,
            };

            return Ok(funcionarioDto);
        }

        // GET api/funcionarios
        // Requisição para puxar todos os funcionários
        [HttpGet]
        public async Task<IActionResult> GetAllFuncionarios()
        {
            var funcionarios = await _context.Funcionarios
                .Select(f => new FuncionarioDto
                {
                    Id = f.Id,
                    Nome = f.Nome,
                    Sexo = f.Sexo,
                    Nacionalidade = f.Nacionalidade,
                    Estado_Civil = f.Estado_Civil,
                    Email = f.Email,
                    Telefone = f.Telefone,
                    RG = f.RG,
                    Data_Nascimento = f.Data_Nascimento,
                    CEP = f.CEP,
                    RF = f.RF,
                    Formacao = f.Formacao,
                    Cargo = f.Cargo,
                    Carga_Horaria = f.Carga_Horaria,
                    Expediente = f.Expediente,
                    Salario = f.Salario,
                    IsActive = f.IsActive,
                    Cpf = f.Cpf,
                    Senha = f.Senha,
                    Role = f.Role,
                })
                .ToListAsync();

            return Ok(funcionarios);
        }

        // GET api/funcionarios/ativo
        // Requesição para puxar todos os funcionários ativos
        [HttpGet("ativo")]
        public async Task<IActionResult> GetActiveFuncionarios()
        {
            var funcionarios = await _context.Funcionarios
                .Where(f => f.IsActive)
                .Select(f => new FuncionarioDto
                {
                    Id = f.Id,
                    Nome = f.Nome,
                    Sexo = f.Sexo,
                    Nacionalidade = f.Nacionalidade,
                    Estado_Civil = f.Estado_Civil,
                    Email = f.Email,
                    Telefone = f.Telefone,
                    RG = f.RG,
                    Data_Nascimento = f.Data_Nascimento,
                    CEP = f.CEP,
                    RF = f.RF,
                    Formacao = f.Formacao,
                    Cargo = f.Cargo,
                    Carga_Horaria = f.Carga_Horaria,
                    Expediente = f.Expediente,
                    Salario = f.Salario,
                    IsActive = f.IsActive,
                    Cpf = f.Cpf,
                    Senha = f.Senha,
                    Role = f.Role,
                })
                .ToListAsync();

            return Ok(funcionarios);
        }

        // GET api/funcionarios/inativo
        // Requesição para puxar todos os funcionários inativos
        [HttpGet("inativo")]
        public async Task<IActionResult> GetInactiveFuncionarios()
        {
            var funcionarios = await _context.Funcionarios
                .Where(f => !f.IsActive)
                .Select(f => new FuncionarioDto
                {
                    Id = f.Id,
                    Nome = f.Nome,
                    Sexo = f.Sexo,
                    Nacionalidade = f.Nacionalidade,
                    Estado_Civil = f.Estado_Civil,
                    Email = f.Email,
                    Telefone = f.Telefone,
                    RG = f.RG,
                    Data_Nascimento = f.Data_Nascimento,
                    CEP = f.CEP,
                    RF = f.RF,
                    Formacao = f.Formacao,
                    Cargo = f.Cargo,
                    Carga_Horaria = f.Carga_Horaria,
                    Expediente = f.Expediente,
                    Salario = f.Salario,
                    IsActive = f.IsActive,
                    Cpf = f.Cpf,
                    Senha = f.Senha,
                    Role = f.Role,
                })
                .ToListAsync();

            return Ok(funcionarios);
        }

        // GET api/funcionarios/{id}
        // Requesição para puxar funcionários via ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFuncionarioById(Guid id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            var funcionarioDto = new FuncionarioDto
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Sexo = funcionario.Sexo,
                Nacionalidade = funcionario.Nacionalidade,
                Estado_Civil = funcionario.Estado_Civil,
                Email = funcionario.Email,
                Telefone = funcionario.Telefone,
                RG = funcionario.RG,
                Data_Nascimento = funcionario.Data_Nascimento,
                CEP = funcionario.CEP,
                RF = funcionario.RF,
                Formacao = funcionario.Formacao,
                Cargo = funcionario.Cargo,
                Carga_Horaria = funcionario.Carga_Horaria,
                Expediente = funcionario.Expediente,
                Salario = funcionario.Salario,
                IsActive = funcionario.IsActive,
                Cpf = funcionario.Cpf,
                Senha = funcionario.Senha,
                Role = funcionario.Role,
            };

            return Ok(funcionarioDto);
        }

        // PUT api/funcionarios/{id}
        // Requisição para atualizar um funcionario
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFuncionario(Guid id, FuncionarioCreateDto funcionarioCreateDto)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            // atualizar os dados
            funcionario.Nome = funcionarioCreateDto.Nome;
            funcionario.Sexo = funcionarioCreateDto.Sexo;
            funcionario.Nacionalidade = funcionarioCreateDto.Nacionalidade;
            funcionario.Estado_Civil = funcionarioCreateDto.Estado_Civil;
            funcionario.Email = funcionarioCreateDto.Email;
            funcionario.Telefone = funcionarioCreateDto.Telefone;
            funcionario.RG = funcionarioCreateDto.RG;
            funcionario.Data_Nascimento = funcionarioCreateDto.Data_Nascimento;
            funcionario.CEP = funcionarioCreateDto.CEP;
            funcionario.Formacao = funcionarioCreateDto.Formacao;
            funcionario.Cargo = funcionarioCreateDto.Cargo;
            funcionario.Carga_Horaria = funcionarioCreateDto.Carga_Horaria;
            funcionario.Expediente = funcionarioCreateDto.Expediente;
            funcionario.Salario = funcionarioCreateDto.Salario;
            funcionario.Senha = funcionarioCreateDto.Senha;

            try
            {
                _context.Entry(funcionario).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar o funcionário.");
                throw;
            }

            return Ok(new { message = "Funcionário atualizado com sucesso." });
        }

        // DELETE api/funcionarios/{id}
        // Requesição para deletar de forma lógica o funcionário
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionario(Guid id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            // Marca o funcionário como inativo
            funcionario.IsActive = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao desativar o funcionário.");
                throw;
            }

            return Ok(new { message = "Funcionário desativado com sucesso." });
        }
    }
}
