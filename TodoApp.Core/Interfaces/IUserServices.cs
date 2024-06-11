using Microsoft.AspNetCore.Mvc;
using TodoApp.Core.Entities;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace TodoApp.Core.Interfaces;

public interface IUserServices
{
    public Task<ActionResult<string>> RegisterUserAsync(TodoUser user, string password);
    public Task<ActionResult<string>> LoginUserAsync(TodoUser user, string password);
}