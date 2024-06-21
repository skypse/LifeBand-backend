namespace LifeBand_backend.Dtos.User
{
    public class UserCredencialDto
    {
        // receber do endpoint
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Cpf { get; set; }
    }
}
