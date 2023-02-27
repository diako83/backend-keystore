using backend_keystore.Data;
using backend_keystore.Models;
using backend_keystore.Models.User;
using Microsoft.EntityFrameworkCore;

namespace backend_keystore.Auth;

public class AuthRepository:IAuthRepository
{
    private readonly DataContext _context;

    public AuthRepository(DataContext context)
    {
        _context = context;
    }

    public Task<ServiceResponse<string>> Login(string username, string password)
    {
        throw new NotImplementedException();
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
}