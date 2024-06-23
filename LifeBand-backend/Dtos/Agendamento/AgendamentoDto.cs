namespace LifeBand_backend.Dtos.Agendamento
{
    public class AgendamentoDto
    {
        public Guid Id { get; set; }
        public Guid FuncionarioId { get; set; }
        public string? FuncionarioNome { get; set; }
        public Guid UserId { get; set; }
        public string? TipoExame { get; set; }
        public DateTime DataExame { get; set; }
        public TimeSpan HorarioExame { get; set; }
        public string? Diagnostico { get; set; }
        public string? Observacoes { get; set; }
        public string? Status { get; set; }
    }
}
