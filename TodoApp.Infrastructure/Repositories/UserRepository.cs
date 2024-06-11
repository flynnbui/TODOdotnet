using Microsoft.AspNetCore.Identity;
using TodoApp.Core.Entities;
using TodoApp.Core.Interfaces;

public class UserRepository : IUserRepository
{
    private readonly UserManager<TodoUser> _userManager;
    private readonly SignInManager<TodoUser> _signInManager;

    public UserRepository(UserManager<TodoUser> userManager, SignInManager<TodoUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IdentityResult> RegisterAsync(TodoUser newUser, string password)
    {
        var result = await _userManager.CreateAsync(newUser, password);
        return result;
    }

    public async Task<SignInResult> LoginAsync(TodoUser user, string password)
    {
        var username = user.UserName;
        var result = await _signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);
        return result;
    }
}