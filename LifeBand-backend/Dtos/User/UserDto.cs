using LifeBand_backend.Dtos.Pulseira;

namespace LifeBand_backend.Dtos.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? Genero { get; set; }
        public string? Tipo_Sanguineo { get; set; }
        public string? RG { get; set; }
        public string? Cpf { get; set; }
        public string? Historico_Medico { get; set; }
        public string? Endereco { get; set; }
        public bool IsActive { get; set; } = true;
        public List<PulseiraDto> Pulseiras { get; set; }
    }
}
