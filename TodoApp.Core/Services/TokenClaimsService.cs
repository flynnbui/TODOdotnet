using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TodoApp.Core.Entities;
using TodoApp.Core.Interfaces;

namespace TodoApp.Core.Services;

public class TokenClaimsService : ITokenClaimsService
{
    private readonly UserManager<TodoUser> _userManager;
    private readonly IConfiguration _configuration;
    public TokenClaimsService(UserManager<TodoUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }
     
    public async Task<string> GenerateJwtToken(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName).ConfigureAwait(false);
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName)
        };

        var jwtKey = _configuration["JWTSettings:Key"];
        var key = Encoding.ASCII.GetBytes(jwtKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
