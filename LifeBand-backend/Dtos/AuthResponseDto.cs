namespace LifeBand_backend.Dtos
{
    public class AuthResponseDto
    {
        // retornar resposta da autenticação
        public string? Mensagem { get; set; }
        public string? Token { get; set; }
    }
}
