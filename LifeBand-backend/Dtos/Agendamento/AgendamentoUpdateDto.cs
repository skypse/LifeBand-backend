namespace LifeBand_backend.Dtos.Agendamento
{
    public class AgendamentoUpdateDto
    {
        public string? TipoExame { get; set; }
        public DateTime DataExame { get; set; }
        public TimeSpan HorarioExame { get; set; }
        public string? Diagnostico { get; set; }
        public string? Observacoes { get; set; }
        public string? Status { get; set; }
    }
}
