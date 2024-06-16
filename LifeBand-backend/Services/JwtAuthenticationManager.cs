using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LifeBand_backend.Services
{
    // implementação do gerenciador de autenticação JWT
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string _key;

        // construtor que aceita secret key para gerar tokens
        public JwtAuthenticationManager(string key)
        {
            _key = key;
        }
        
        // gerar um token JWT com base no Email e CPF do usuário!
        public string GenerateToken(string email, string cpf)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_key); // pega chave secreta e converte para bytes
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, email), // adiciona o email como uma claim
                    new Claim("CPF", cpf) // adiciona o CPF como uma claim

                }),
                Expires = DateTime.UtcNow.AddHours(2), // expiração do token para 2 horas
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature) // algoritmo de assinatura
            };
            var token = tokenHandler.CreateToken(tokenDescriptor); // cria o token JWT
            return tokenHandler.WriteToken(token); // retorna o token JWT como string
        }
    }
}
