using System;
using System.ComponentModel.DataAnnotations;

namespace JWTAuth.DTO
{
    public class UserCredential
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

