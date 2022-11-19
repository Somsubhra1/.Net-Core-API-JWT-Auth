using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTAuth.DTO;
using JWTAuth.IRepositories;
using JWTAuth.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace JWTAuth.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly IJwtTokenManager _jwtTokenManager;
        private readonly IUserRepository _userRepository;


        public TokenController(IJwtTokenManager jwtTokenManager, IUserRepository userRepository)
        {
            _jwtTokenManager = jwtTokenManager;
            _userRepository = userRepository;
        }


        [HttpPost("Authenticate")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] UserCredential credential)
        {
            var user = await _userRepository.GetUserAsync(credential.UserName, credential.Password);

            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            var token = _jwtTokenManager.Authenticate(credential.UserName);

            return Ok(token);
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> MeAsync()
        {
            var token = HttpContext.GetTokenAsync("access_token").Result;
            var userName = _jwtTokenManager.DecodeToken(token);
            var user = await _userRepository.GetUserByUserNameAsync(userName);

            return Ok(user);
        }
    }
}

