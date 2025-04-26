using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RO.DevTest.Application.Contracts.Services;
using RO.DevTest.Domain.Entities;
using System;
using System.Collections.Generic; 
using System.IdentityModel.Tokens.Jwt;
using System.Linq; 
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RO.DevTest.Application.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    public async Task<string?> LoginAsync(string userName, string password)
    {
        var user = await _userManager.FindByNameAsync(userName);

        if (user == null)
        {
            return null;
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            return GenerateJwtToken(user);
        }

        return null;
    }

    public async Task<string?> RegisterAsync(string username, string password, string email, string name)
    {
        var user = new User { UserName = username, Email = email, Name = name };
        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            return GenerateJwtToken(user);
        }

       
        if (result.Errors.Any())
        {
            return string.Join("\n", result.Errors.Select(error => error.Description));
        }

        return "Falha desconhecida ao registrar o usuário.";
    }

    private string GenerateJwtToken(User user)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var secretKey = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]);
        var issuer = jwtSettings["Issuer"];
        var audience = jwtSettings["Audience"];

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("name", user.Name),

            }),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature),
            Issuer = issuer,
            Audience = audience
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}