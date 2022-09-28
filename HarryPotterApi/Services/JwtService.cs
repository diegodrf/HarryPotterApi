using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Models.Data;
using Microsoft.IdentityModel.Tokens;

namespace Api.Services;

public class JwtService: IJwtService
{
    private readonly string _secretKey;

    public JwtService(string secretKey)
    {
        _secretKey = secretKey;
    }
    
    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Name, user.Id.ToString()),
                new(ClaimTypes.Role, user.Role),
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}