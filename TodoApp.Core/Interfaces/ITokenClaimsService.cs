using Microsoft.AspNetCore.Mvc;
using TodoApp.Core.Entities;

namespace TodoApp.Core.Interfaces;

public interface ITokenClaimsService
{
    Task<string> GenerateJwtToken(string userName);
}