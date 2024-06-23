using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LifeBand_backend.Services
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string _key;

        public JwtAuthenticationManager(string key)
        {
            _key = key;
        }

        public string GenerateToken(string email, string cpf, bool isFuncionario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_key);

            // definição dos claims, a serem incluídos no token JWT
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, email), // nome usuario
                new Claim("CPF", cpf),// cpf usuario
                new Claim(ClaimTypes.Role, isFuncionario ? "Funcionario" : "Paciente") // claim para definir a role
            };

            // descrição token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2), // expirar depois de 2 horas
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature) // definindo o uso da chave simétrica e o algoritmo HMAC SHA-256
            };

            var token = tokenHandler.CreateToken(tokenDescriptor); // criação token com base na descrição
            return tokenHandler.WriteToken(token); // retorna o token como string
        }
    }
}
