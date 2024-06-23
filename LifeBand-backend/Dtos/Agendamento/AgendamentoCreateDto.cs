namespace LifeBand_backend.Dtos.Agendamento
{
    public class AgendamentoCreateDto
    {
        public Guid UserId { get; set; } // ID paciente associado ao agendamento
        public string? FuncionarioNome { get; set; } // Funcionário responsável pelo agendamento
        public string? TipoExame { get; set; }
        public DateTime DataExame { get; set; }
        public TimeSpan HorarioExame { get; set; }
        public string? Diagnostico { get; set; }
        public string? Observacoes { get; set; }
    }
}
