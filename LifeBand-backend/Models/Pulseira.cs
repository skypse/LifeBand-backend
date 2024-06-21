namespace LifeBand_backend.Models
{
    public class Pulseira
    {
        public Guid Id { get; set; }
        public string? ContatoEmergenciaNome { get; set; }
        public string? ContatoEmergenciaTelefone { get; set; }
        public string? DoencaCronica { get; set; }
        public string? GrauDeRisco { get; set; }
        public bool IsActive { get; set; } = true;

        // foreign key
        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
