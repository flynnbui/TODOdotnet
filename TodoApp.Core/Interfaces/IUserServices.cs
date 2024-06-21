using Microsoft.AspNetCore.Mvc;
using TodoApp.Core.Entities;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace TodoApp.Core.Interfaces;

public interface IUserServices
{
    public Task<ActionResult<string>> RegisterUserAsync(string userName, string password);
    public Task<ActionResult<string>> LoginUserAsync(string userName, string password);
    public Task<TodoUser> GetUserDetailsAsync(string userId);
}