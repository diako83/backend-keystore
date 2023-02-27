using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using backend_keystore.Data;
using backend_keystore.Models;
using backend_keystore.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace backend_keystore.Auth;

public class AuthRepository:IAuthRepository
{
    private readonly DataContext _context;
    private readonly IConfiguration _configuration;

    public AuthRepository(DataContext context,IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<ServiceResponse<string>> Login(string username, string password)
    {
        var response = new ServiceResponse<string>();
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username.ToLower().Equals(username.ToLower()));
        if (user is null)
        {
            response.Success = false;
            response.Message = "User not found.";
        }
        else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            response.Success = false;
            response.Message = "Wrong password.";
        }
        else
        {
            response.Data = CreateToken(user);
        }

        return response;
        
    }
    
    public async Task<ServiceResponse<string>> Register(User user, string password)
    {
        var responce = new ServiceResponse<string>();
        if (await UserExists(user.Username))
        {
            responce.Success = false;
            responce.Message = "user already exists";
            return responce;
        }
        
        CreatePasswordHash(password,out byte[] passwordHash, out byte[] passwordSalts);
        user.Id = Guid.NewGuid().ToString();
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalts;   
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
       
        responce.Data = user.Id;
        return responce;
    }
    public async Task<bool> UserExists(string username)
    {
        if (await _context.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower()))
        {
            return true;
        }

        return false;
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalts)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalts = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }   
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalts)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalts))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
     
    } 
    
    
    private string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.Username)
        };

        var appSettingsToken = _configuration.GetSection("AppSettings:Token").Value;
        if (appSettingsToken is null)
            throw new Exception("AppSettings Token is null");
        
        SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
            .GetBytes(appSettingsToken));

        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = creds
        };

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
