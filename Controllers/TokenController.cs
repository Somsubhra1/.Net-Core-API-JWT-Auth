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
        public IActionResult Authenticate([FromBody] UserCredential credential)
        {

            if (_userRepository.GetUser(credential.UserName, credential.Password) == null)
            {
                return Unauthorized("Invalid username or password");
            }

            var token = _jwtTokenManager.Authenticate(credential.UserName, credential.Password);

            return Ok(token);
        }

        [Authorize]
        [HttpGet("me")]
        public IActionResult Me()
        {
            var token = HttpContext.GetTokenAsync("access_token").Result;

            var userName = _jwtTokenManager.DecodeToken(token);
            return Ok(userName);
        }
    }
}

