namespace LifeBand_backend.Models
{
    public class Agendamento
    {
        public Guid Id { get; set; }
        // foreign key para funcionario
        public Guid FuncionarioId { get; set; }
        public Funcionario? FuncionarioResponsavel { get; set; }
        public Guid UserId { get; set; } // ID do paciente (UserId)
        public string? TipoExame { get; set; }
        public DateTime DataExame { get; set; }
        public TimeSpan HorarioExame { get; set; }
        public string? Diagnostico { get; set; }
        public string? Observacoes { get; set; }
        public string? Status { get; set; } = "ATIVO";
    }
}
