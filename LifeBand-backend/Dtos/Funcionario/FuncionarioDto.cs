namespace LifeBand_backend.Dtos.Funcionario
{
    public class FuncionarioDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Sexo { get; set; }
        public string? Nacionalidade { get; set; }
        public string? Estado_Civil { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? RG { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string? CEP { get; set; }
        public Guid RF { get; set; }
        public string? Formacao { get; set; }
        public string? Cargo { get; set; }
        public int Carga_Horaria { get; set; }
        public string? Expediente { get; set; }
        public decimal Salario { get; set; }
        public bool IsActive { get; set; } = true;
        public string? Senha { get; set; }
        public string? Cpf { get; set; }
        public string Role { get; set; } = "Funcionario";
    }
}
