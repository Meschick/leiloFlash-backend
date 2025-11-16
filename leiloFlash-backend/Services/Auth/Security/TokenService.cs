using leiloFlash_backend.Enums;
using leiloFlash_backend.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace leiloFlash_backend.Services.Auth.Security
{
    public class TokenService : ITokenService
    {

        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GerarToken(UsuarioModel usuario)
        {
            StatusEnum statusDoUsuario = StatusEnum.Ativo;
            string statusEmString = statusDoUsuario.ToString();

            var key = new SymmetricSecurityKey(
           Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
         );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, StatusEnum.Ativo.ToString()),

            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
