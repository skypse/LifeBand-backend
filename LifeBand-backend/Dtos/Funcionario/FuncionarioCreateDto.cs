namespace LifeBand_backend.Dtos.Funcionario
{
    public class FuncionarioCreateDto
    {
        public string? Nome { get; set; }
        public string? Sexo { get; set; }
        public string? Nacionalidade { get; set; }
        public string? Estado_Civil { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? RG { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string? CEP { get; set; }
        public string? Formacao { get; set; }
        public string? Cargo { get; set; }
        public int Carga_Horaria { get; set; }
        public string? Expediente { get; set; }
        public decimal Salario { get; set; }
        public string? Senha { get; set; }
        public string? Cpf { get; set; }
    }
}
