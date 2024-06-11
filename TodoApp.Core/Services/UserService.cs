using Microsoft.AspNetCore.Mvc;
using TodoApp.Core.Entities;
using TodoApp.Core.Interfaces;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace TodoApp.Core.Services;

public class UserService : IUserServices
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenClaimsService _tokenClaimsService;

    public UserService(IUserRepository userRepository, ITokenClaimsService tokenClaimsService)
    {
        _userRepository = userRepository;
        _tokenClaimsService = tokenClaimsService;
    }
    public async Task<ActionResult<string>> RegisterUserAsync(TodoUser user, string password)
    {
        var result = await _userRepository.RegisterAsync(user, password);
        if (result.Succeeded)
        {
            var token = _tokenClaimsService.GenerateJwtToken(user);
            return token;
        }
        return new BadRequestObjectResult("User registration failed");
    }

    public async Task<ActionResult<string>> LoginUserAsync(TodoUser user, string password)
    {
        var result = await _userRepository.LoginAsync(user, password);
        if (result == SignInResult.Success)
        {
            var token = _tokenClaimsService.GenerateJwtToken(user);
            return token;
        }
        return new BadRequestObjectResult("User login failed");
    }
}