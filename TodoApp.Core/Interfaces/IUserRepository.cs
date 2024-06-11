using Microsoft.AspNetCore.Identity;
using TodoApp.Core.DTOs;
using TodoApp.Core.Entities;

namespace TodoApp.Core.Interfaces;

public interface IUserRepository
{
    Task<IdentityResult> RegisterAsync(TodoUser user, string password);
    Task<SignInResult> LoginAsync(TodoUser user, string password);
}