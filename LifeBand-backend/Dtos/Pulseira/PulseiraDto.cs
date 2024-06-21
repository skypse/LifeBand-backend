namespace LifeBand_backend.Dtos.Pulseira
{
    public class PulseiraDto
    {
        public Guid Id { get; set; }
        public string? ContatoEmergenciaNome { get; set; }
        public string? ContatoEmergenciaTelefone { get; set; }
        public string? DoencaCronica { get; set; }
        public string? GrauDeRisco { get; set; }
        public bool IsActive { get; set; } = true;
        public Guid UserId { get; set; }
    }
}
