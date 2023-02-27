using backend_keystore.Auth;
using backend_keystore.Dto;
using backend_keystore.Dto.UserDto;
using backend_keystore.Models;
using backend_keystore.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace backend_keystore.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController:ControllerBase
{

    private readonly IAuthRepository _authRepo;

    public AuthController(IAuthRepository authRepo)
    {
        _authRepo = authRepo;
    }
    
    
    [HttpPost("register")]
    public async Task<ActionResult<ServiceResponse<string>>> Register(UserRegisterDto request)
    {
        var response = await _authRepo.Register(
            new User { Username = request.Username }, request.Password
        );
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    [HttpPost("login")]
    public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto request)
    {
        var response = await _authRepo.Login(request.Username, request.Password);
        if(!response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
    
}