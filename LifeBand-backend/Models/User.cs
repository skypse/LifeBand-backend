namespace LifeBand_backend.Models
{
    public class User
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
        public string? Password { get; set; }
        public string? Endereco { get; set; }
        public bool IsActive { get; set; } = true; // indica se o usuário está ativo ou desativado

        public ICollection<Pulseira> Pulseiras { get; set; }
    }
}
