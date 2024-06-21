namespace LifeBand_backend.Dtos.Pulseira
{
    public class PulseiraCreateDto
    {
        public string? ContatoEmergenciaNome { get; set; }
        public string? ContatoEmergenciaTelefone { get; set; }
        public string? DoencaCronica { get; set; }
        public string? GrauDeRisco { get; set; }
        public Guid UserId { get; set; }
    }
}
