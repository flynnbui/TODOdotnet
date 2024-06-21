using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Core.Entities;
using TodoApp.Core.Interfaces;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace TodoApp.Core.Services;

public class UserServices : IUserServices
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenClaimsService _tokenClaimsService;
    private readonly UserManager<TodoUser> _userManager;

    public UserServices(IUserRepository userRepository, ITokenClaimsService tokenClaimsService, UserManager<TodoUser> userManager)
    {
        _userRepository = userRepository;
        _tokenClaimsService = tokenClaimsService;
        _userManager = userManager;
    }
    public async Task<ActionResult<string>> RegisterUserAsync(string userName, string password)
    {
        var result = await _userRepository.RegisterAsync(userName, password).ConfigureAwait(false);
        if (result.Succeeded)
        {
            var token = await _tokenClaimsService.GenerateJwtToken(userName);
            return token;
        }
        return new BadRequestObjectResult("User registration failed");
    }

    public async Task<ActionResult<string>> LoginUserAsync(string userName, string password)
    {
        var result = await _userRepository.LoginAsync(userName, password).ConfigureAwait(false);
        if (result == SignInResult.Success)
        {
            var token = await _tokenClaimsService.GenerateJwtToken(userName);
            return token;
        }
        return new BadRequestObjectResult("User login failed");
    }

    public async Task<TodoUser> GetUserDetailsAsync(string userId)
    {
        var user = await _userRepository.GetUserAsync(userId).ConfigureAwait(false);
        return user;
    }
}