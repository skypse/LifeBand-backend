namespace LifeBand_backend.Services
{
    public interface IJwtAuthenticationManager
    {
        string GenerateToken(string email, string cpf);
    }
}
