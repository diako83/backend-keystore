using backend_keystore.Models;
using backend_keystore.Models.User;

namespace backend_keystore.Auth;

public interface IAuthRepository
{
    Task<ServiceResponse<string>> Register(User user, string password);
    Task<ServiceResponse<string>> Login(string username, string password);
    Task<bool> UserExists(string username);
    
}