using TodoApp.Core.Entities;

namespace TodoApp.Core.Interfaces;

public interface ITokenClaimsService
{
    string GenerateJwtToken(TodoUser user);
}