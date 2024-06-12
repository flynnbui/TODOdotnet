using Microsoft.AspNetCore.Identity;
using TodoApp.Core.DTOs;
using TodoApp.Core.Entities;

namespace TodoApp.Core.Interfaces;

public interface IUserRepository
{
    Task<IdentityResult> RegisterAsync(string userName, string password);
    Task<SignInResult> LoginAsync(string userName, string password);
}