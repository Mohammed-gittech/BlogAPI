using BlogAPI.Application.DTOs;
using Microsoft.AspNetCore.Identity;

namespace BlogAPI.Application.Interfaces;

public interface IAuthService
{
    Task<IdentityResult> RegisterAsync(RegisterDto dto);
    Task<string?> LoginAsync(LoginDto dto);
}