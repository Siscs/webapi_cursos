using System.Text;
using lxwebapijwt.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;
using Microsoft.AspNetCore.Identity;

namespace lxwebapijwt.Services
{
    public static class TokenService
    {
        public static string GerarToken(IdentityUser usuarioAuh, TokenConfig tokenConfig)
        {

            //usuarioAuh.


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = tokenConfig.Emissor,
                Audience = tokenConfig.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(tokenConfig.ExpiracaoHoras),
                SigningCredentials = 
                    new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}