using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace JWTAuth.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class NameController : Controller
    {
        [HttpGet("GetNames")]
        public IActionResult GetNames()
        {
            var token = HttpContext.GetTokenAsync("access_token").Result; // get the token using this in controller


            return Ok(new List<string> { "name1", "name2" });
        }


    }
}

