using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Core.DTOs;
using TodoApp.Core.Interfaces;

namespace TodoApp.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;
        private readonly ITokenClaimsService _tokenClaimsService;

        public UserController(IUserServices userServices,
            IMapper mapper,
            ITokenClaimsService tokenClaimsService)
        {
            _userServices = userServices;
            _mapper = mapper;
            _tokenClaimsService = tokenClaimsService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<String>> Login(UserInfo user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userServices.LoginUserAsync(user.UserName, user.Password).ConfigureAwait(false);
            if (result.Value == null)
            {
                return new BadRequestObjectResult("Something went wrong!");
            }
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<String>> Register(UserInfo user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userServices.RegisterUserAsync(user.UserName, user.Password).ConfigureAwait(false);
            if (result.Value == null)
            {
                return new BadRequestObjectResult("User registration failed");
            }
            return Ok(result);
        }
    }
}
