using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Filmes.Models;
using Microsoft.IdentityModel.Tokens;

namespace Filmes.Services;

public class TokenService
{
    public string GenerateToken(User user)
    {
        Claim[] claims = new Claim[]
        {
            new("username", user.UserName),
            new("id", user.Id),
            new(ClaimTypes.DateOfBirth, user.DateBirth.ToString()),
            new("loginTimestamp", DateTime.UtcNow.ToString())
        };


        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hASFD151ASDAFA98ASD54ASDA777"));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.Aes128CbcHmacSha256);


        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddMinutes(10),
            claims: claims,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}